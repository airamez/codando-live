using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async;

public class PiHuntertApp
{
  static int manCol;
  static int manRow;
  static readonly string floorChar = "░";
  static readonly string wallChar = "▓";
  static readonly string objectChar = "π";
  static readonly string manChar = "☻";
  static int collectedObjects = 0;
  static int objectToCollect = 0;

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

    // Initialize the timer
    Stopwatch timer = new Stopwatch();
    timer.Start();

    // Create a cancellation token source for stopping the background task
    var cts = new CancellationTokenSource();
    // Start the real-time status updater in a background task
    Task.Run(() => UpdateStatus(timer, cts.Token));

    while (true)
    {
      if (collectedObjects == objectToCollect)
      {
        break;
      }
      // Wait for user input
      var key = Console.ReadKey(intercept: true).Key;

      // Exit the program if the user presses 'Q' or Escape
      if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
        break;

      // Calculate the new position of the "man"
      int newX = manCol, newY = manRow;

      switch (key)
      {
        case ConsoleKey.UpArrow:
          newY = manRow > 0 ? manRow - 1 : manRow;
          break;
        case ConsoleKey.DownArrow:
          newY = manRow < mapHeight - 1 ? manRow + 1 : manRow;
          break;
        case ConsoleKey.LeftArrow:
          newX = manCol > 0 ? manCol - 1 : manCol;
          break;
        case ConsoleKey.RightArrow:
          newX = manCol < mapWidth - 1 ? manCol + 1 : manCol;
          break;
      }

      // Check if the new position is valid (not a wall)
      if (map[newY, newX] != wallChar)
      {
        // Erase the "man" from the current position
        lock (consoleLock)
        {
          Console.SetCursorPosition(manCol, manRow);
          //          Console.Write(map[manRow, manCol]);
          Console.Write(floorChar);
        }

        // Update the "man" position
        manCol = newX;
        manRow = newY;

        // Check if the "man" collects an object
        if (map[manRow, manCol] == objectChar)
        {
          collectedObjects++;
          map[manRow, manCol] = floorChar; // Remove the object from the map
        }

        // Redraw the "man" at the new position
        lock (consoleLock)
        {
          Console.SetCursorPosition(manCol, manRow);
          Console.Write(manChar);
        }
      }
    }

    TimeSpan elapsedTime = timer.Elapsed;
    PrintStatus(elapsedTime);
    // Exit message
    Console.WriteLine();
    Console.WriteLine("Thanks for playing! Goodbye.");
    if (collectedObjects == objectToCollect)
    {
      Console.WriteLine($"CONGRATULATIONS!!! You collected all objects in {elapsedTime:hh\\:mm\\:ss}");
    }
    else
    {
      Console.WriteLine($"BOOOOOOOOOOOOO!!! You only collected {collectedObjects} objects");
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
        map[row, col] = floorChar;

        // Randomly place walls
        if (random.Next(100) < 20) // 20% chance for a wall
        {
          map[row, col] = wallChar;
        }

        // Randomly place objects
        if (random.Next(100) < 10 && map[row, col] != wallChar) // 10% chance for an object
        {
          map[row, col] = objectChar;
          objectToCollect++;
        }
      }
    }

    // Ensure the starting position is clear and set it to the middle
    manCol = mapWidth / 2;
    manRow = mapHeight / 2;
    // If the middle position is an object, decrement the object to collect counter
    if (map[manRow, manCol] == objectChar)
    {
      objectToCollect--;
    }
    // Make sure the middle position is not a wall or object
    map[manRow, manCol] = manChar;
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
      // Update the status line every 200 milliseconds
      TimeSpan elapsedTime = timer.Elapsed;
      PrintStatus(elapsedTime);
      Thread.Sleep(200); // Refresh interval
    } while (!token.IsCancellationRequested);
  }

  static void PrintStatus(TimeSpan elapsedTime)
  {
    lock (consoleLock)
    {
      Console.SetCursorPosition(0, mapHeight + 1);
      Console.Write($"Collected Objects: {collectedObjects}/{objectToCollect} | Time Elapsed: {elapsedTime:hh\\:mm\\:ss} ");
    }
  }
}
