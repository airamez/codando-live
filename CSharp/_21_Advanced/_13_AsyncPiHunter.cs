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
  public const int MAP_WIDTH = 40; // Map Width
  public const int MAP_HEIGHT = 20; // Map Height
  public const string FLOOR = "▒";
  public const string WALL = "█";
  public const string PI = "π"; q
  public const string HUNTER = "☻";
  public const string MONSTER = "∞";
  static public bool IsGameOver { private set; get; }
  static public int PlayerCurrentCol { private set; get; }
  static public int PlayerCurrentRow { private set; get; }

  private int collectedCounter = 0;
  private int totalToCollectCounter = 0;
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
    Console.SetBufferSize(Math.Max(MAP_WIDTH, Console.BufferWidth), Math.Max(MAP_HEIGHT + 5, Console.BufferHeight));
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
          newRow = PlayerCurrentRow < MAP_HEIGHT - 1 ? PlayerCurrentRow + 1 : PlayerCurrentRow;
          break;
        case ConsoleKey.LeftArrow:
          newCol = PlayerCurrentCol > 0 ? PlayerCurrentCol - 1 : PlayerCurrentCol;
          break;
        case ConsoleKey.RightArrow:
          newCol = PlayerCurrentCol < MAP_WIDTH - 1 ? PlayerCurrentCol + 1 : PlayerCurrentCol;
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
    map = new string[MAP_HEIGHT, MAP_WIDTH];

    for (int row = 0; row < MAP_HEIGHT; row++)
    {
      for (int col = 0; col < MAP_WIDTH; col++)
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
    PlayerCurrentCol = MAP_WIDTH / 2;
    PlayerCurrentRow = MAP_HEIGHT / 2;
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
      var monster = new Monster(map, consoleLock);
      monsters.Add(monster);
      monster.Spawn();
    }
  }

  private void DrawMap()
  {
    Console.SetCursorPosition(0, 0);
    for (int row = 0; row < MAP_HEIGHT; row++)
    {
      for (int col = 0; col < MAP_WIDTH; col++)
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
    PrintAt(MAP_HEIGHT + 1, 0, status);
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
  private Random random;
  private int monsterCol;
  private int monsterRow;

  public Monster(string[,] map, object consoleLock)
  {
    this.map = map;
    this.consoleLock = consoleLock;
    this.random = new Random();
  }

  public void Spawn()
  {
    do
    {
      monsterRow = random.Next(PiHunterGame.MAP_HEIGHT);
      monsterCol = random.Next(PiHunterGame.MAP_WIDTH);
    } while (map[monsterRow, monsterCol] != PiHunterGame.FLOOR &&
             map[monsterRow, monsterCol] != PiHunterGame.PI);
    map[monsterRow, monsterCol] = PiHunterGame.MONSTER;
    PrintAt(monsterRow, monsterCol, PiHunterGame.MONSTER);
  }

  public void Move()
  {
    while (!PiHunterGame.IsGameOver)
    {
      int newRow = monsterRow + random.Next(-1, 2); // Move up, down, or stay
      int newCol = monsterCol + random.Next(-1, 2); // Move left, right, or stay
      if (newRow >= 0 &&
          newRow < PiHunterGame.MAP_HEIGHT &&
          newCol >= 0 &&
          newCol < PiHunterGame.MAP_WIDTH && map[newRow, newCol] != PiHunterGame.WALL &&
          newCol < PiHunterGame.MAP_WIDTH && map[newRow, newCol] != PiHunterGame.PI)
      {
        // If monster and player are in the same or adjacents positions
        if (Math.Abs(monsterRow - PiHunterGame.PlayerCurrentRow) <= 1 &&
            Math.Abs(monsterCol - PiHunterGame.PlayerCurrentCol) <= 1)
        {
          PrintAt(PiHunterGame.MAP_HEIGHT + 2, 0, "GAME OVER: The monster caught you!");
          Environment.Exit(0);
        }
        PrintAt(monsterRow, monsterCol, PiHunterGame.FLOOR);
        monsterRow = newRow;
        monsterCol = newCol;
        PrintAt(monsterRow, monsterCol, PiHunterGame.MONSTER);
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
