using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

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
  static public bool IsGameOver { private set; get; }
  static public int PlayerCurrentCol { private set; get; }
  static public int PlayerCurrentRow { private set; get; }
  readonly string FLOOR = "▒";
  readonly string WALL = "█";
  readonly string PI = "π";
  readonly string HUNTER = "☻";
  private int collectedCounter = 0;
  private int totalToCollectCounter = 0;
  private int mapWidth = 40; // Width of the map
  private int mapHeight = 20; // Height of the map
  private string[,] map; // 2D array to represent the map
  private readonly object consoleLock = new object(); // Lock object for console synchronization
  private Stopwatch timer = new Stopwatch();
  private Random random;
  private List<Monster> monsters = new List<Monster>(); // List to hold multiple monsters

  public void Start()
  {
    random = new Random();
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    Console.SetBufferSize(Math.Max(mapWidth, Console.BufferWidth), Math.Max(mapHeight + 5, Console.BufferHeight));
    Console.CursorVisible = false; // Hide the cursor for better presentation
    InitializeMap();
    DrawMap();
    SpawnMonsters(4); // Spawn three monsters
    timer.Start();
    Task.Run(() => UpdateStatus());
    foreach (var monster in monsters)
    {
      Task.Run(() => monster.Move());
    }
    IsGameOver = false;
    while (!IsGameOver)
    {
      if (collectedCounter == totalToCollectCounter)
      {
        IsGameOver = true;
      }
      // Wait for user input
      var key = Console.ReadKey(intercept: true).Key;
      // Exit the program if the user presses 'Q' or Escape
      if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
      {
        IsGameOver = true;
      }
      // Calculate the new position of the "man"
      int newCol = PlayerCurrentCol;
      int newRow = PlayerCurrentRow;
      switch (key)
      {
        case ConsoleKey.UpArrow:
          newRow = PlayerCurrentRow > 0 ? PlayerCurrentRow - 1 : PlayerCurrentRow;
          break;
        case ConsoleKey.DownArrow:
          newRow = PlayerCurrentRow < mapHeight - 1 ? PlayerCurrentRow + 1 : PlayerCurrentRow;
          break;
        case ConsoleKey.LeftArrow:
          newCol = PlayerCurrentCol > 0 ? PlayerCurrentCol - 1 : PlayerCurrentCol;
          break;
        case ConsoleKey.RightArrow:
          newCol = PlayerCurrentCol < mapWidth - 1 ? PlayerCurrentCol + 1 : PlayerCurrentCol;
          break;
      }
      // Check if the new position is valid (not a wall)
      if (map[newRow, newCol] != WALL)
      {
        // Erase the hunter from the current position
        PrintAt(PlayerCurrentRow, PlayerCurrentCol, FLOOR);
        // Update the hunter position
        PlayerCurrentCol = newCol;
        PlayerCurrentRow = newRow;
        // Check if the hunter collects an object
        if (map[PlayerCurrentRow, PlayerCurrentCol] == PI)
        {
          collectedCounter++;
          map[PlayerCurrentRow, PlayerCurrentCol] = FLOOR; // Remove the object from the map
        }
        // Redraw the hunter at the new position
        PrintAt(PlayerCurrentRow, PlayerCurrentCol, HUNTER);
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
    PlayerCurrentCol = mapWidth / 2;
    PlayerCurrentRow = mapHeight / 2;
    if (map[PlayerCurrentRow, PlayerCurrentCol] == PI)
    {
      totalToCollectCounter--;
    }
    map[PlayerCurrentRow, PlayerCurrentCol] = HUNTER;
  }

  private void SpawnMonsters(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var monster = new Monster(map, consoleLock, FLOOR, mapWidth, mapHeight);
      monsters.Add(monster);
      monster.Spawn();
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
    } while (!IsGameOver);
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

public class Monster
{
  private readonly string[,] map;
  private readonly object consoleLock;
  private readonly string floor;
  private readonly int mapWidth;
  private readonly int mapHeight;
  private Random random;
  private int monsterCol;
  private int monsterRow;
  private const string MONSTER = "∞";

  public Monster(string[,] map, object consoleLock, string floor, int mapWidth, int mapHeight)
  {
    this.map = map;
    this.consoleLock = consoleLock;
    this.floor = floor;
    this.mapWidth = mapWidth;
    this.mapHeight = mapHeight;
    this.random = new Random();
  }

  public void Spawn()
  {
    do
    {
      monsterRow = random.Next(mapHeight);
      monsterCol = random.Next(mapWidth);
    } while (map[monsterRow, monsterCol] != floor);
    map[monsterRow, monsterCol] = MONSTER;
    PrintAt(monsterRow, monsterCol, MONSTER);
  }

  public void Move()
  {
    while (!PiHunterGame.IsGameOver)
    {
      int newRow = monsterRow + random.Next(-1, 2); // Move up, down, or stay
      int newCol = monsterCol + random.Next(-1, 2); // Move left, right, or stay
      string currentChar = map[monsterRow, monsterCol];
      if (newRow >= 0 && newRow < mapHeight && newCol >= 0 && newCol < mapWidth && map[newRow, newCol] != "█")
      {
        if (Math.Abs(monsterRow - PiHunterGame.PlayerCurrentRow) <= 1 &&
            Math.Abs(monsterCol - PiHunterGame.PlayerCurrentCol) <= 1)
        {
          PrintAt(mapHeight + 2, 0, "GAME OVER: The monster caught you!");
          Environment.Exit(0);
        }
        PrintAt(monsterRow, monsterCol, currentChar);
        monsterRow = newRow;
        monsterCol = newCol;
        PrintAt(monsterRow, monsterCol, MONSTER);
      }
      Thread.Sleep(300);
    }
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
