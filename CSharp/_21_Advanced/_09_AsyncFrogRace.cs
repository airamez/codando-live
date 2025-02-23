using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
  public class FrogRaceApp
  {
    public static async Task Main(string[] args)
    {
      // Start the frog race
      await race();
    }

    public static async Task race()
    {
      const int RACE_DISTANCE = 10; // Defines the race length

      // Set console encoding to support emojis
      Console.OutputEncoding = Encoding.UTF8;
      Console.Clear(); // Clears the console screen
      Console.WriteLine("🐸 Welcome to the Frog Race! 🐸");
      Console.WriteLine($"Race Distance: {RACE_DISTANCE}");
      Console.WriteLine("".PadLeft(RACE_DISTANCE + 10, '-') + "🏁");

      // Create a list of frogs, each with a unique row position in the console
      ConcurrentBag<Frog> frogs = new ConcurrentBag<Frog>();
      for (int i = 1; i <= 5; i++)
      {
        frogs.Add(new Frog($"🐸 {i}", i, RACE_DISTANCE));
      }

      // Thread-safe queue to store the ranking in the order frogs finish
      var ranking = new ConcurrentQueue<Frog>();

      // Start all frogs' race tasks concurrently
      List<Task> raceTasks = frogs.Select(frog => frog.Race(ranking)).ToList();

      // Wait for all frogs to finish before proceeding
      await Task.WhenAll(raceTasks);

      // Move the cursor down to print final ranking
      Console.SetCursorPosition(0, frogs.Count + 5);
      Console.WriteLine("\n🏁 Race Over! Final Ranking:");

      int position = 1;
      while (ranking.TryDequeue(out Frog finishedFrog))
      {
        // Print the final race results based on the actual finishing order
        Console.WriteLine($"#{position} => {finishedFrog.Name}");
        position++;
      }
    }
  }

  public class Frog
  {
    private readonly Random _random; // Each frog gets its own random instance

    public string Name { get; } // Frog's name
    private int DistanceCovered { get; set; } // Tracks how far the frog has jumped
    private int ConsoleRow { get; } // Stores the row in which the frog's progress is displayed
    private int JumpDelay { get; set; } // Time delay after each jump
    private int RaceDistance; // The total distance to complete the race

    private static readonly object consoleLock = new object(); // Lock object for console synchronization

    public Frog(string name, int consoleRow, int raceDistance)
    {
      RaceDistance = raceDistance;
      Name = name;
      DistanceCovered = 0;
      ConsoleRow = consoleRow;

      // Each frog gets a unique random seed to ensure different behaviors
      _random = new Random(Guid.NewGuid().GetHashCode());

      // Initial random delay to add variation at the start of the race
      JumpDelay = _random.Next(100, 300);
    }

    /// <summary>
    /// Asynchronous method that makes the frog jump toward the finish line.
    /// This method runs in parallel with other frogs, demonstrating asynchronous execution.
    /// The return type "Task" represents an ongoing operation that will complete in the future.
    /// </summary>
    public async Task Race(ConcurrentQueue<Frog> ranking)
    {
      // Keep jumping until the frog covers the required distance
      while (DistanceCovered < RaceDistance)
      {
        int jump = _random.Next(1, 5); // Each jump is between 1 and 4 units
        DistanceCovered += jump; // Update the frog's position
        ShowProgress(); // Display updated progress on the console

        // Increase delay after each jump to make the race more unpredictable
        JumpDelay += _random.Next(50, 150);

        // "await Task.Delay(JumpDelay)" makes the frog pause asynchronously.
        // This means the frog's race continues in the background without blocking other frogs.
        await Task.Delay(JumpDelay);
      }

      // When the frog reaches the finish line, add it to the ranking queue
      ranking.Enqueue(this);

      // Move the cursor to the frog's row and print the rank
      lock (consoleLock)
      {
        Console.SetCursorPosition(RaceDistance + 10, ConsoleRow + 3);
        Console.WriteLine($"#{ranking.Count}");
      }
    }

    private void ShowProgress()
    {
      // Set cursor to the frog's assigned row and display its progress
      lock (consoleLock)
      {
        Console.SetCursorPosition(0, ConsoleRow + 3);
        Console.Write($"{Name}: " + new string('=', Math.Min(DistanceCovered, RaceDistance)) + "🐸");
      }
    }
  }
}
