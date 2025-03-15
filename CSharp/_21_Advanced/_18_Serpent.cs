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
  public const int SERPENT_MOVEMENT_DELAY = 200;
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
    Serpent = new Serpent(Constants.MAP_WIDTH / 2, Constants.MAP_HEIGHT / 2);
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
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
      Console.SetWindowSize(Constants.MAP_WIDTH + 2, Constants.MAP_HEIGHT + 3);
      Console.SetBufferSize(Constants.MAP_WIDTH + 2, Constants.MAP_HEIGHT + 3);
    }
    DrawBorder(Constants.MAP_WIDTH, Constants.MAP_HEIGHT);
    DrawBackground();
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

  private async Task Movement()
  {
    while (GameRunning)
    {
      Cell newHead = Serpent.CalculateNextHead();
      if (newHead.X == Fruit.Position.X && newHead.Y == Fruit.Position.Y)
      {
        Serpent.Grow();
        Score++;
        UpdateScoreDisplay();
        GenerateFruit();
      }
      else
      {
        Cell previousTail = Serpent.Body[^1];
        Serpent.Move();
        DrawAt(previousTail.Y, previousTail.X, Constants.BACKGROUND); // Clear previous tail with floor character
      }
      Serpent.CheckCollision();
      DrawAt(Serpent.Head.Y, Serpent.Head.X, Constants.SERPENT_HEAD); // Serpent head
      foreach (var part in Serpent.Body.Skip(1))
      {
        DrawAt(part.Y, part.X, Constants.SERPENT_BODY); // Serpent body
      }
      DrawFruit(); // Ensure the fruit is always drawn
      await Task.Delay(Constants.SERPENT_MOVEMENT_DELAY);
    }
  }

  private void DrawBorder(int width, int height)
  {
    for (int x = 0; x <= width; x++)
    {
      DrawAt(0, x, Constants.BORDER);
      DrawAt(height, x, Constants.BORDER);
    }
    for (int y = 0; y <= height; y++)
    {
      DrawAt(y, 0, Constants.BORDER);
      DrawAt(y, width, Constants.BORDER);
    }
  }

  private void DrawBackground()
  {
    for (int y = 1; y < Constants.MAP_HEIGHT; y++)
    {
      for (int x = 1; x < Constants.MAP_WIDTH; x++)
      {
        DrawAt(y, x, Constants.BACKGROUND); // Fill background with a subtle floor texture
      }
    }
  }

  private void GenerateFruit()
  {
    Fruit = new Fruit(Constants.MAP_WIDTH, Constants.MAP_HEIGHT, Serpent.Body);
  }

  private void DrawFruit()
  {
    DrawAt(Fruit.Position.Y, Fruit.Position.X, Constants.FRUIT);
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
  /// X-coordinate of the point.
  /// </summary>
  public int X { get; set; }

  /// <summary>
  /// Y-coordinate of the point.
  /// </summary>
  public int Y { get; set; }

  /// <summary>
  /// Initializes a new instance of the Point class with specified X and Y coordinates.
  /// </summary>
  /// <param name="x">The X-coordinate of the point.</param>
  /// <param name="y">The Y-coordinate of the point.</param>
  public Cell(int x, int y)
  {
    X = x;
    Y = y;
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
  /// <param name="startX">The X-coordinate of the starting position.</param>
  /// <param name="startY">The Y-coordinate of the starting position.</param>
  public Serpent(int startX, int startY)
  {
    Body = new List<Cell> { new Cell(startX, startY) }; // Initialize the body with the starting head position
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
    return new Cell(Head.X + leftRightDirection, Head.Y + upDownDirection);
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
    if (Head.X <= 0 || Head.Y <= 0 || Head.X >= Constants.MAP_WIDTH || Head.Y >= Constants.MAP_HEIGHT)
    {
      result = true;
    }
    else
    {
      // Check if the serpent's head collides with its body
      for (int i = 1; i < Body.Count; i++)
      {
        if (Head.X == Body[i].X && Head.Y == Body[i].Y)
        {
          result = true;
          break;
        }
      }
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
  /// <param name="width">The width of the map.</param>
  /// <param name="height">The height of the map.</param>
  /// <param name="serpentBody">The list of points representing the serpent's body.</param>
  public Fruit(int width, int height, List<Cell> serpentBody)
  {
    do
    {
      // Generate a random position for the fruit
      Position = new Cell(SerpentGame.Random.Next(1, width), SerpentGame.Random.Next(1, height));
    } while (serpentBody.Exists(p => p.X == Position.X && p.Y == Position.Y)); // Ensure it does not overlap with the serpent
  }
}