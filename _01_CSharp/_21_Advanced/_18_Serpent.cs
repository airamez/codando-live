// https://www.youtube.com/watch?v=7r83N3c2kPw

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advanced;

public class SerpentGameApp
{
  public static async Task Main()
  {
    var serpentGame = new SerpentGame();
    await serpentGame.Run();
  }
}

public class Constants
{
  public const string BACKGROUND = "░";
  public const string BORDER = "▓";
  public const string FRUIT = "■";
  public const string SERPENT_HEAD = "¤";
  public const string SERPENT_BODY = "●";
  public const int MAP_WIDTH = 40;
  public const int MAP_HEIGHT = 20;
  public const int SERPENT_MOVEMENT_DELAY = 150;
}

public class SerpentGame
{
  private static readonly object consoleLock = new object();
  private Serpent Serpent;
  private Fruit Fruit;
  private int Score = 0;
  private bool GameRunning = true;
  public static readonly Random Random = new Random();

  public async Task Run()
  {
    Initialize();
    await WaitToStart();
    Serpent = new Serpent(Constants.MAP_HEIGHT / 2, Constants.MAP_WIDTH / 2);
    GenerateFruit();
    var movementTask = Movement();
    var inputTask = Task.Run(async () =>
    {
      while (GameRunning)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKey key = Console.ReadKey(intercept: true).Key;
          if (key == ConsoleKey.Escape)
          {
            GameRunning = false;
            break;
          }
          Serpent.ChangeDirection(key);
        }
        await Task.Delay(10); // Reduce CPU usage
      }
    });
    await Task.WhenAny(movementTask, inputTask);
    DrawAt(Constants.MAP_WIDTH / 2 - 5, Constants.MAP_HEIGHT / 2, "Bye bye!!!");
  }

  private void Initialize()
  {
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    Console.CursorVisible = false;
    // Check if the OS is Windows
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
      Console.SetWindowSize(Constants.MAP_WIDTH + 2, Constants.MAP_HEIGHT + 3);
      Console.SetBufferSize(Constants.MAP_WIDTH + 2, Constants.MAP_HEIGHT + 3);
    }
    DrawBorder();
    DrawBackground();
    UpdateScoreDisplay();
  }

  private static async Task WaitToStart()
  {
    DrawAt(2, 6, " Welcome to the Serpent Game! ");
    DrawAt(3, 6, " Escape = Exit; Arrows = Move ");
    DrawAt(4, 6, " Press any Arrow to start!!   ");
    ConsoleKey key;
    do
    {
      key = Console.ReadKey(intercept: true).Key;
      if (key == ConsoleKey.Escape)
      {
        Environment.Exit(0);
      }
      await Task.Delay(10);
    } while (key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow &&
             key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow);
    DrawAt(2, 1, "".PadLeft(Constants.MAP_WIDTH - 2, Constants.BACKGROUND[0]));
    DrawAt(3, 1, "".PadLeft(Constants.MAP_WIDTH - 2, Constants.BACKGROUND[0]));
    DrawAt(4, 1, "".PadLeft(Constants.MAP_WIDTH - 2, Constants.BACKGROUND[0]));
  }

  public static void EndGame()
  {
    DrawAt(Constants.MAP_HEIGHT + 3, 0, "GAME OVER!!!");
    Environment.Exit(0);
  }

  /// <summary>
  /// Handles the core movement logic for the serpent game.
  /// Moves the serpent in the current direction, handles collisions, 
  /// grows the serpent when it consumes fruit, and updates the game state.
  /// </summary>
  /// <returns>A task representing the asynchronous movement loop of the game.</returns>
  private async Task Movement()
  {
    while (GameRunning)
    {
      // Calculate the serpent's new head position
      Cell newHead = Serpent.CalculateNextHead();

      // Check if the serpent eats the fruit
      if (newHead.Row == Fruit.Position.Row &&
          newHead.Col == Fruit.Position.Col)
      {
        Serpent.Grow(); // Grow the serpent
        Score++; // Increment the score
        UpdateScoreDisplay(); // Update the score display
        GenerateFruit(); // Generate a new fruit at a random position
      }
      else
      {
        // Clear the previous tail position with the background character
        Cell previousTail = Serpent.Body[^1]; // The last element of the list
        Serpent.Move(); // Move the serpent
        DrawAt(previousTail.Row, previousTail.Col, Constants.BACKGROUND);
      }
      // Check for collisions with walls or the serpent's own body
      Serpent.CheckCollision();
      // Draw the serpent's head
      DrawAt(Serpent.Head.Row, Serpent.Head.Col, Constants.SERPENT_HEAD);
      // Draw the serpent's body (skipping the head)
      foreach (var part in Serpent.Body.Skip(1))
      {
        DrawAt(part.Row, part.Col, Constants.SERPENT_BODY);
      }
      // Ensure the fruit remains visible on the map
      DrawFruit();
      // Pause for a moment to control the serpent's movement speed
      await Task.Delay(Constants.SERPENT_MOVEMENT_DELAY);
    }
  }


  private void DrawBorder()
  {
    for (int row = 0; row <= Constants.MAP_HEIGHT; row++)
    {
      DrawAt(row, 0, Constants.BORDER);
      DrawAt(row, Constants.MAP_WIDTH, Constants.BORDER);
    }
    for (int col = 0; col <= Constants.MAP_WIDTH; col++)
    {
      DrawAt(0, col, Constants.BORDER);
      DrawAt(Constants.MAP_HEIGHT, col, Constants.BORDER);
    }
  }

  private void DrawBackground()
  {
    for (int y = 1; y < Constants.MAP_HEIGHT; y++)
    {
      for (int x = 1; x < Constants.MAP_WIDTH; x++)
      {
        DrawAt(y, x, Constants.BACKGROUND);
      }
    }
  }

  private void GenerateFruit()
  {
    Fruit = new Fruit(Serpent.Body);
  }

  private void DrawFruit()
  {
    DrawAt(Fruit.Position.Row, Fruit.Position.Col, Constants.FRUIT);
  }

  private void UpdateScoreDisplay()
  {
    string scoreText = $"Score: {Score}";
    DrawAt(Constants.MAP_HEIGHT + 1, 0, scoreText);
  }

  public static void DrawAt(int row, int col, string content)
  {
    lock (consoleLock)
    {
      Console.SetCursorPosition(col, row);
      Console.Write(content);
    }
  }
}

/// <summary>
/// Represents a point in a 2D space with X and Y coordinates.
/// </summary>
public class Cell
{
  /// <summary>
  /// Row of the point.
  /// </summary>
  public int Row { get; set; }

  /// <summary>
  /// Column of the point.
  /// </summary>
  public int Col { get; set; }


  /// <summary>
  /// Initializes a new instance of the Point class with specified X and Y coordinates.
  /// </summary>
  /// <param name="col">The Row of the point.</param>
  /// <param name="row">The Column of the point.</param>
  public Cell(int row, int col)
  {
    Col = col;
    Row = row;
  }
}

/// <summary>
/// Represents the serpent in the game, including its body, movement, and collision logic.
/// </summary>
public class Serpent
{
  /// <summary>
  /// List of points that make up the serpent's body. The first point is the head.
  /// </summary>
  public List<Cell> Body { get; private set; }

  // Movement deltas for the serpent's direction.
  private int leftRightDirection, upDownDirection;

  /// <summary>
  /// Gets the head of the serpent (the first point in its body).
  /// </summary>
  public Cell Head => Body[0];

  /// <summary>
  /// Initializes the serpent at a specific starting position.
  /// </summary>
  /// <param name="startCol">The X-coordinate of the starting position.</param>
  /// <param name="startRow">The Y-coordinate of the starting position.</param>
  public Serpent(int startRow, int startCol)
  {
    Body = new List<Cell> { new Cell(startRow, startCol) }; // Initialize the body with the starting head position 
    leftRightDirection = 1; // Default horizontal movement
    upDownDirection = 0; // No vertical movement initially
  }

  /// <summary>
  /// Changes the direction of movement for the serpent based on the arrow key pressed.
  /// Ensures that the serpent does not reverse direction into its own body.
  /// </summary>
  /// <param name="key">
  /// The arrow key pressed by the player:
  /// - <see cref="ConsoleKey.UpArrow"/> to move upward.
  /// - <see cref="ConsoleKey.DownArrow"/> to move downward.
  /// - <see cref="ConsoleKey.LeftArrow"/> to move left.
  /// - <see cref="ConsoleKey.RightArrow"/> to move right.
  /// </param>
  /// <remarks>
  /// This method uses the following rules to update the direction:
  /// - Moving Up: Only allowed when not already moving vertically (upDownDirection == 0).
  /// - Moving Down: Only allowed when not already moving vertically (upDownDirection == 0).
  /// - Moving Left: Only allowed when not already moving horizontally (leftRightDirection == 0).
  /// - Moving Right: Only allowed when not already moving horizontally (leftRightDirection == 0).
  ///
  /// The `leftRightDirection` and `upDownDirection` values indicate the current direction:
  /// - `leftRightDirection` manages horizontal movement:
  ///   - `-1`: Moving left.
  ///   - `1`: Moving right.
  ///   - `0`: No horizontal movement.
  /// - `upDownDirection` manages vertical movement:
  ///   - `-1`: Moving up.
  ///   - `1`: Moving down.
  ///   - `0`: No vertical movement.
  ///
  /// Together, `leftRightDirection` and `upDownDirection` ensure smooth and valid directional changes.
  /// </remarks>
  /// <example>
  /// If the serpent is moving right (`leftRightDirection = 1, upDownDirection = 0`) and the Up Arrow key is pressed:
  /// - `leftRightDirection` is set to `0` (no horizontal movement).
  /// - `upDownDirection` is set to `-1` (move upward).
  /// This prevents invalid direction reversal into the body.
  /// </example>
  public void ChangeDirection(ConsoleKey key)
  {
    switch (key)
    {
      case ConsoleKey.UpArrow:       // Update direction to move upward
        if (upDownDirection == 0)    // If not moving UP or DOWN
        {
          leftRightDirection = 0;    // Stop LEFT/RIGHT movement
          upDownDirection = -1;      // Move UP
        }
        break;
      case ConsoleKey.DownArrow:     // Update direction to move downward
        if (upDownDirection == 0)    // If not moving moving UP or DOWN
        {
          leftRightDirection = 0;    // Stop LEFT/RIGHT movement
          upDownDirection = 1;       // Mode DOWN
        }
        break;
      case ConsoleKey.LeftArrow:     // Update direction to move left
        if (leftRightDirection == 0) // if not moving LEFT or RIGHT
        {
          leftRightDirection = -1;   // Move LEFT
          upDownDirection = 0;       // Stop UP/DOWN movement
        }
        break;
      case ConsoleKey.RightArrow:    // Update direction to move right
        if (leftRightDirection == 0) // If not moving LEFT or RIGHT
        {
          leftRightDirection = 1;    // Move RIGHT
          upDownDirection = 0;       // Stop UP/DOWN movement
        }
        break;
    }
  }

  /// <summary>
  /// Calculates the next position of the serpent's head based on its current direction.
  /// </summary>
  /// <returns>A new Point representing the next head position.</returns>
  public Cell CalculateNextHead()
  {
    return new Cell(Head.Row + upDownDirection, Head.Col + leftRightDirection);
  }

  /// <summary>
  /// Moves the serpent in the current direction. The head moves forward, and the tail is removed.
  /// </summary>
  public void Move()
  {
    Cell newHead = CalculateNextHead();
    Body.Insert(0, newHead); // Add the new head at the front of the body
    Body.RemoveAt(Body.Count - 1); // Remove the last segment (tail)
  }

  /// <summary>
  /// Grows the serpent by adding a new head without removing the tail.
  /// </summary>
  public void Grow()
  {
    Cell newHead = CalculateNextHead();
    Body.Insert(0, newHead); // Add the new head at the front of the body
  }

  /// <summary>
  /// Checks if the serpent collides with itself or the boundaries of the map.
  /// Ends the game if a collision occurs.
  /// </summary>
  /// <param name="width">The width of the map.</param>
  /// <param name="height">The height of the map.</param>
  public void CheckCollision()
  {
    var result = false;
    // Check if the serpent's head collides with the map's borders
    if (Head.Col <= 0 || Head.Row <= 0 || Head.Col >= Constants.MAP_WIDTH || Head.Row >= Constants.MAP_HEIGHT)
    {
      result = true;
    }
    else
    {
      // Check if the serpent's head collides with its body
      result = Body.Skip(1).Any(bodyCell => bodyCell.Row == Head.Row && bodyCell.Col == Head.Col);
    }
    if (result)
    {
      SerpentGame.EndGame(); // Ends the game if a collision is detected
    }
  }
}

/// <summary>
/// Represents a fruit on the game map, including its position and generation logic.
/// </summary>
public class Fruit
{
  /// <summary>
  /// The position of the fruit on the map.
  /// </summary>
  public Cell Position { get; private set; }

  /// <summary>
  /// Initializes a new instance of the Fruit class and places it at a random position.
  /// Ensures the fruit does not overlap with the serpent's body.
  /// </summary>
  /// <param name="serpentBody">The list of points representing the serpent's body.</param>
  public Fruit(List<Cell> serpentBody)
  {
    // Ensure it does not overlap with the serpent
    do
    {
      // Generate a random position for the fruit
      var newRandomRow = SerpentGame.Random.Next(1, Constants.MAP_HEIGHT);
      var newRandomCol = SerpentGame.Random.Next(1, Constants.MAP_WIDTH);
      Position = new Cell(newRandomRow, newRandomCol);
    } while (serpentBody.Exists(p => p.Row == Position.Row && p.Col == Position.Col));
  }
}