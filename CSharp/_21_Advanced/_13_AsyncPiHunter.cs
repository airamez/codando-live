using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class PiHunterApp
{
  static void Main(string[] args)
  {
    PiHunterGame game = new PiHunterGame();
    game.Start();
  }
}

public class PiHunterGame
{
  private int currentCol;
  private int currentRow;
  private int monsterCol;
  private int monsterRow;
  readonly string FLOOR = "▒";
  readonly string WALL = "█";
  string PI = "π";
  readonly string HUNTER = "☻";
  readonly string MONSTER = "∞";
  readonly int MONSTER_SLEEP = 300;
  private int collectedCounter = 0;
  private int totalToCollectCounter = 0;
  private int mapWidth = 40; // Width of the map
  private int mapHeight = 20; // Height of the map
  private string[,] map; // 2D array to represent the map
  private readonly object consoleLock = new object(); // Lock object for console synchronization
  private Stopwatch timer = new Stopwatch();
  private bool gameOver;
  private Random random;

  public void Start()
  {
    random = new Random();
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    // This only works in Windows
    Console.SetBufferSize(Math.Max(mapWidth, Console.BufferWidth), Math.Max(mapHeight + 5, Console.BufferHeight));
    Console.CursorVisible = false; // Hide the cursor for better presentation
    InitializeMap();
    DrawMap();
    PlaceMonster();
    timer.Start();
    Task.Run(() => UpdateStatus());
    Task.Run(() => MoveMonster());
    gameOver = false;
    while (!gameOver)
    {
      if (collectedCounter == totalToCollectCounter)
      {
        gameOver = true;
      }
      // Wait for user input
      var key = Console.ReadKey(intercept: true).Key;
      // Exit the program if the user presses 'Q' or Escape
      if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
      {
        gameOver = true;
      }
      // Calculate the new position of the "man"
      int newCol = currentCol;
      int newRow = currentRow;
      switch (key)
      {
        case ConsoleKey.UpArrow:
          newRow = currentRow > 0 ? currentRow - 1 : currentRow;
          break;
        case ConsoleKey.DownArrow:
          newRow = currentRow < mapHeight - 1 ? currentRow + 1 : currentRow;
          break;
        case ConsoleKey.LeftArrow:
          newCol = currentCol > 0 ? currentCol - 1 : currentCol;
          break;
        case ConsoleKey.RightArrow:
          newCol = currentCol < mapWidth - 1 ? currentCol + 1 : currentCol;
          break;
      }
      // Check if the new position is valid (not a wall)
      if (map[newRow, newCol] != WALL)
      {
        // Erase the hunter from the current position
        PrintAt(currentRow, currentCol, FLOOR);
        // Update the hunter position
        currentCol = newCol;
        currentRow = newRow;
        // Check if the hunter collects an object
        if (map[currentRow, currentCol] == PI)
        {
          collectedCounter++;
          map[currentRow, currentCol] = FLOOR; // Remove the object from the map
        }
        // Redraw the hunter at the new position
        PrintAt(currentRow, currentCol, HUNTER);
      }
    }

    PrintStatus();
    // Exit message
    Console.WriteLine();
    Console.WriteLine("Thanks for playing! Goodbye.");
    if (collectedCounter == totalToCollectCounter)
    {
      TimeSpan elapsedTime = timer.Elapsed;
      Console.WriteLine($"CONGRATULATIONS!!! You collected all objects in {elapsedTime:hh\\:mm\\:ss}");
    }
    else
    {
      Console.WriteLine($"BOOOOOOOOOOOOO!!! You only collected {collectedCounter} objects");
    }
  }

  private void InitializeMap()
  {
    map = new string[mapHeight, mapWidth];

    for (int row = 0; row < mapHeight; row++)
    {
      for (int col = 0; col < mapWidth; col++)
      {
        // Fill the map with the default character
        map[row, col] = FLOOR;

        // Randomly place walls
        if (random.Next(100) < 20) // 20% chance for a wall
        {
          map[row, col] = WALL;
        }

        // Randomly place objects
        if (random.Next(100) < 10 && map[row, col] != WALL) // 10% chance for an object
        {
          map[row, col] = PI;
          totalToCollectCounter++;
        }
      }
    }

    // Ensure the starting position is clear and set it to the middle
    currentCol = mapWidth / 2;
    currentRow = mapHeight / 2;
    // If the middle position is an object, decrement the object to collect counter
    if (map[currentRow, currentCol] == PI)
    {
      totalToCollectCounter--;
    }
    // Make sure the middle position is not a wall or object
    map[currentRow, currentCol] = HUNTER;
  }

  private void PlaceMonster()
  {
    Random random = new Random();
    do
    {
      monsterRow = random.Next(mapHeight);
      monsterCol = random.Next(mapWidth);
    } while (map[monsterRow, monsterCol] != FLOOR); // Ensure monster spawns on a valid floor tile
    map[monsterRow, monsterCol] = MONSTER;
    PrintAt(monsterRow, monsterCol, MONSTER);
  }

  private void MoveMonster()
  {
    while (!gameOver)
    {
      int newRow = monsterRow + random.Next(-1, 2); // Move up, down, or stay
      int newCol = monsterCol + random.Next(-1, 2); // Move left, right, or stay

      if (newRow >= 0 && newRow < mapHeight && newCol >= 0 && newCol < mapWidth && map[newRow, newCol] != WALL)
      {
        PrintAt(monsterRow, monsterCol, FLOOR);
        monsterRow = newRow;
        monsterCol = newCol;
        PrintAt(monsterRow, monsterCol, MONSTER);
        if (monsterRow == currentRow && monsterCol == currentCol)
        {
          PrintAt(mapHeight + 2, 0, "GAME OVER: The monster caught you!");
          Environment.Exit(0);
        }
      }
    }
  }

  private void DrawMap()
  {
    Console.SetCursorPosition(0, 0);
    for (int row = 0; row < mapHeight; row++)
    {
      for (int col = 0; col < mapWidth; col++)
      {
        Console.Write(map[row, col]);
      }
      Console.WriteLine();
    }
  }

  private void UpdateStatus()
  {
    do
    {
      PrintStatus();
      Thread.Sleep(200); // Refresh interval
    } while (!gameOver);
  }

  private void PrintStatus()
  {
    TimeSpan elapsedTime = timer.Elapsed;
    string status = $"Collected Objects: {collectedCounter}/{totalToCollectCounter} | Time Elapsed: {elapsedTime:hh\\:mm\\:ss} [Press 'ESC' or 'Q' to quit]";
    PrintAt(mapHeight + 1, 0, status);
  }

  private void PrintAt(int row, int col, string content)
  {
    lock (consoleLock)
    {
      Console.SetCursorPosition(col, row);
      Console.Write(content);
    }
  }
}
