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
  public const string FLOOR = "░";
  public const string WALL = "▓";
  public const string PI = "π";
  public const string PLAYER = "☻";
  public const string MONSTER = "∞";
  static public bool IsGameOver { private set; get; }
  static public int PlayerCol { private set; get; }
  static public int PlayerRow { private set; get; }

  private int CollectedCounter { set; get; }
  private int TotalToCollectCounter { set; get; }
  private string[,] Map; // 2D array to represent the map
  private readonly object consoleLock = new object(); // Lock object for console synchronization
  private Stopwatch Timer = new Stopwatch();
  public static Random Random { private set; get; }
  private List<Monster> monsters = new List<Monster>(); // List to hold multiple monsters

  public void Start()
  {
    Random = new Random();
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    Console.SetBufferSize(Math.Max(MAP_WIDTH, Console.BufferWidth), Math.Max(MAP_HEIGHT + 5, Console.BufferHeight)); // Only works on Windows
    Console.CursorVisible = false; // Hide the cursor for better presentation
    CollectedCounter = 0;
    TotalToCollectCounter = 0;
    InitializeMap();
    DrawMap();
    Timer.Start();
    Task.Run(() => UpdateStatus());
    SpawnMonsters(4); // Spawn three monsters
    foreach (var monster in monsters)
    {
      Task.Run(() => monster.Move());
    }
    IsGameOver = false;
    while (!IsGameOver) // Game loop
    {
      // Wait for user input
      var key = Console.ReadKey(intercept: true).Key;
      // Exit the program if the user presses 'Q' or Escape
      if (key == ConsoleKey.Escape)
      {
        IsGameOver = true;
        break;
      }
      int newCol = PlayerCol;
      int newRow = PlayerRow;
      switch (key)
      {
        case ConsoleKey.UpArrow:
          newRow = PlayerRow > 0 ? PlayerRow - 1 : PlayerRow;
          break;
        case ConsoleKey.DownArrow:
          newRow = PlayerRow < MAP_HEIGHT - 1 ? PlayerRow + 1 : PlayerRow;
          break;
        case ConsoleKey.LeftArrow:
          newCol = PlayerCol > 0 ? PlayerCol - 1 : PlayerCol;
          break;
        case ConsoleKey.RightArrow:
          newCol = PlayerCol < MAP_WIDTH - 1 ? PlayerCol + 1 : PlayerCol;
          break;
        case ConsoleKey.Spacebar:
          UseBomb();
          break;
      }
      // Check if the new position is valid (not a wall)
      if (Map[newRow, newCol] != WALL)
      {
        // Erase the hunter from the current position
        PrintAt(PlayerRow, PlayerCol, FLOOR);
        // Update the hunter position
        PlayerCol = newCol;
        PlayerRow = newRow;
        // Check if the hunter collected an PI
        if (Map[PlayerRow, PlayerCol] == PI)
        {
          CollectedCounter++;
          Map[newRow, newCol] = FLOOR;
        }
        // Draw the hunter at the new position
        PrintAt(PlayerRow, PlayerCol, PLAYER);
        // Check for Victory
        if (CollectedCounter == TotalToCollectCounter)
        {
          IsGameOver = true;
        }
      }
    }

    PrintStatus();
    // Exit message
    Console.WriteLine();
    Console.WriteLine("Thanks for playing! Goodbye.");
    if (CollectedCounter == TotalToCollectCounter)
    {
      TimeSpan elapsedTime = Timer.Elapsed;
      Console.WriteLine($"CONGRATULATIONS!!! You collected all objects in {elapsedTime:hh\\:mm\\:ss}");
    }
    else
    {
      Console.WriteLine($"BOOOOOOOOOOOOO!!! You only collected {CollectedCounter} objects");
    }
  }

  private void UseBomb()
  {
    for (int row = PlayerRow - 1; row <= PlayerRow + 1; row++)
    {
      for (int col = PlayerCol - 1; col <= PlayerCol + 1; col++)
      {
        if (row >= 0 && row < MAP_HEIGHT &&
            col >= 0 && col < MAP_WIDTH)
        {
          if (Map[row, col] == WALL)
          {
            PrintAt(row, col, FLOOR);
            Map[row, col] = FLOOR;
          }
        }
      }
    }
  }

  private void InitializeMap()
  {
    Map = new string[MAP_HEIGHT, MAP_WIDTH];
    for (int row = 0; row < MAP_HEIGHT; row++)
    {
      for (int col = 0; col < MAP_WIDTH; col++)
      {
        // Fill the map with the default character
        Map[row, col] = FLOOR;
        // Randomly place walls
        if (Random.Next(100) < 20) // 20% chance for a wall
        {
          Map[row, col] = WALL;
        }
        // Randomly place PIs
        if (Random.Next(100) < 10 &&
            Map[row, col] != WALL) // 10% chance for an PI
        {
          Map[row, col] = PI;
          TotalToCollectCounter++;
        }
      }
    }

    // Ensure the starting position is clear and set it to the middle
    PlayerCol = MAP_WIDTH / 2;
    PlayerRow = MAP_HEIGHT / 2;
    if (Map[PlayerRow, PlayerCol] == PI)
    {
      TotalToCollectCounter--;
    }
    Map[PlayerRow, PlayerCol] = PLAYER;
  }

  private void SpawnMonsters(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var monster = new Monster(Map, consoleLock);
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
        Console.Write(Map[row, col]);
      }
      Console.WriteLine();
    }
  }

  private void UpdateStatus()
  {
    do
    {
      PrintStatus();
      Thread.Sleep(1000); // Refresh interval
    } while (!IsGameOver);
  }

  private void PrintStatus()
  {
    TimeSpan elapsedTime = Timer.Elapsed;
    string status = $"Collected Objects: {CollectedCounter}/{TotalToCollectCounter} | Time Elapsed: {elapsedTime:hh\\:mm\\:ss} [Press 'SPACE BAR' for Bomb and 'ESC' to quit]";
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
  private int monsterCol;
  private int monsterRow;

  public Monster(string[,] map, object consoleLock)
  {
    this.map = map;
    this.consoleLock = consoleLock;
  }

  public void Spawn()
  {
    do
    {
      monsterRow = PiHunterGame.Random.Next(PiHunterGame.MAP_HEIGHT);
      monsterCol = PiHunterGame.Random.Next(PiHunterGame.MAP_WIDTH);
    } while (map[monsterRow, monsterCol] != PiHunterGame.FLOOR &&
             map[monsterRow, monsterCol] != PiHunterGame.PI);
    lock (consoleLock)
    {
      map[monsterRow, monsterCol] = PiHunterGame.MONSTER;
      PrintAt(monsterRow, monsterCol, PiHunterGame.MONSTER);
    }
  }

  public void Move()
  {
    while (!PiHunterGame.IsGameOver)
    {
      int newRow = monsterRow + PiHunterGame.Random.Next(-1, 2); // Move up, down, or stay
      int newCol = monsterCol + PiHunterGame.Random.Next(-1, 2); // Move left, right, or stay
      if (newRow >= 0 &&
          newRow < PiHunterGame.MAP_HEIGHT &&
          newCol >= 0 &&
          newCol < PiHunterGame.MAP_WIDTH &&
          map[newRow, newCol] != PiHunterGame.WALL &&
          newCol < PiHunterGame.MAP_WIDTH &&
          map[newRow, newCol] != PiHunterGame.PI)
      {
        // If monster and player are in the same or adjacents positions is GAME OVER
        if (Math.Abs(monsterRow - PiHunterGame.PlayerRow) <= 1 &&
            Math.Abs(monsterCol - PiHunterGame.PlayerCol) <= 1)
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