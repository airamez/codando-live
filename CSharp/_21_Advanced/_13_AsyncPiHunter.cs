using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class PiHuntertApp
{
  static int currentCol;
  static int currentRow;
  static readonly string FLOOR = "▒";
  static readonly string WALL = "█";
  static readonly string PI = "π";
  static readonly string HUNTER = "☻";
  static readonly string MONSTER = "∞";
  static int collectedCounter = 0;
  static int totalToCollectCounter = 0;
  static int mapWidth = 40; // Width of the map
  static int mapHeight = 20; // Height of the map
  static string[,] map; // 2D array to represent the map
  private static readonly object consoleLock = new object(); // Lock object for console synchronization


  static void Main(string[] args)
  {
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;
    // This only works in Windows
    Console.SetBufferSize(Math.Max(mapWidth, Console.BufferWidth), Math.Max(mapHeight + 2, Console.BufferHeight));
    Console.CursorVisible = false; // Hide the cursor for better presentation
    // Initialize and draw the map with walls and objects
    InitializeMap();
    DrawMap();
    Stopwatch timer = new Stopwatch();
    timer.Start();
    // Create a cancellation token source for stopping the background task
    var cancelationToken = new CancellationTokenSource();
    // Start the real-time status updater in a background task
    Task.Run(() => UpdateStatus(timer, cancelationToken.Token));
    while (true)
    {
      if (collectedCounter == totalToCollectCounter)
      {
        break;
      }
      // Wait for user input
      var key = Console.ReadKey(intercept: true).Key;
      // Exit the program if the user presses 'Q' or Escape
      if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
        break;
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

    TimeSpan elapsedTime = timer.Elapsed;
    PrintStatus(elapsedTime);
    // Exit message
    Console.WriteLine();
    Console.WriteLine("Thanks for playing! Goodbye.");
    if (collectedCounter == totalToCollectCounter)
    {
      Console.WriteLine($"CONGRATULATIONS!!! You collected all objects in {elapsedTime:hh\\:mm\\:ss}");
    }
    else
    {
      Console.WriteLine($"BOOOOOOOOOOOOO!!! You only collected {collectedCounter} objects");
    }
  }

  static void InitializeMap()
  {
    map = new string[mapHeight, mapWidth];
    Random random = new Random();

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

  static void DrawMap()
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

  static void UpdateStatus(Stopwatch timer, CancellationToken token)
  {
    do
    {
      TimeSpan elapsedTime = timer.Elapsed;
      PrintStatus(elapsedTime);
      Thread.Sleep(200); // Refresh interval
    } while (!token.IsCancellationRequested);
  }

  static void PrintStatus(TimeSpan elapsedTime)
  {
    string status = $"Collected Objects: {collectedCounter}/{totalToCollectCounter} | Time Elapsed: {elapsedTime:hh\\:mm\\:ss} [Press 'ESC' or 'Q' to quit]";
    PrintAt(mapHeight + 1, 0, status);
  }

  static void PrintAt(int row, int col, string content)
  {
    lock (consoleLock)
    {
      Console.SetCursorPosition(col, row);
      Console.Write(content);
    }
  }
}
