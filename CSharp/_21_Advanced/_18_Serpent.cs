using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Advanced;

public class SerpentApp
{
  private static Snake snake;
  private static Point fruit;
  public const int WIDTH = 40;
  public const int HEIGHT = 20;
  private static bool gameRunning = true;
  private readonly object consoleLock = new object(); // Lock object for console synchronization


  public static async Task Main()
  {
    Console.Clear();
    Console.OutputEncoding = Encoding.UTF8;

    Console.CursorVisible = false;
    Console.SetWindowSize(WIDTH + 2, HEIGHT + 2);
    Console.SetBufferSize(WIDTH + 2, HEIGHT + 2);

    DrawBorder(WIDTH, HEIGHT);

    snake = new Snake(WIDTH / 2, HEIGHT / 2);
    fruit = Fruit.Generate(WIDTH, HEIGHT, snake.Body);
    fruit.Draw(ConsoleColor.Red);

    // Start async snake movement
    _ = SnakeMovement();

    // Main loop: processes user input only
    while (gameRunning)
    {
      var key = Console.ReadKey(intercept: true).Key;

      if (key == ConsoleKey.Escape)
      {
        gameRunning = false;
      }
      else
      {
        snake.ChangeDirection(key);
      }
    }

    Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT / 2);
    Console.WriteLine("Game Over!");
  }

  private static async Task SnakeMovement()
  {
    while (gameRunning)
    {
      // Calculate the new head position
      Point previousTail = snake.Body[snake.Body.Count - 1];
      Point newHead = snake.CalculateNextHead();

      // Check collision with fruit
      if (newHead.X == fruit.X && newHead.Y == fruit.Y)
      {
        snake.Grow();
        fruit = Fruit.Generate(WIDTH, HEIGHT, snake.Body);
        fruit.Draw(ConsoleColor.Red);
      }
      else
      {
        // Clear the last segment of the tail
        Console.SetCursorPosition(previousTail.X, previousTail.Y);
        Console.Write(' ');
        snake.Move();
      }

      // Check for collision with walls or itself
      if (snake.CheckCollision(WIDTH, HEIGHT))
      {
        gameRunning = false;
        break;
      }

      // Draw the new head
      Console.SetCursorPosition(newHead.X, newHead.Y);
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("O");
      Console.ResetColor();

      // Wait asynchronously for the next movement update
      await Task.Delay(100);
    }
  }

  private static void DrawBorder(int width, int height)
  {
    for (int x = 0; x <= width; x++)
    {
      Console.SetCursorPosition(x, 0);
      Console.Write('#');
      Console.SetCursorPosition(x, height);
      Console.Write('#');
    }
    for (int y = 0; y <= height; y++)
    {
      Console.SetCursorPosition(0, y);
      Console.Write('#');
      Console.SetCursorPosition(width, y);
      Console.Write('#');
    }
  }
}

public class Point
{
  public int X { get; set; }
  public int Y { get; set; }

  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }

  public void Draw(ConsoleColor color)
  {
    Console.SetCursorPosition(X, Y);
    Console.ForegroundColor = color;
    Console.Write("🍎");
    Console.ResetColor();
  }
}

public class Snake
{
  public List<Point> Body { get; private set; }
  private int dx, dy;

  public Point Head => Body[0];

  public Snake(int startX, int startY)
  {
    Body = new List<Point> { new Point(startX, startY) };
    dx = 1; dy = 0; // Initial movement direction
  }

  public void ChangeDirection(ConsoleKey key)
  {
    switch (key)
    {
      case ConsoleKey.UpArrow when dy == 0: dx = 0; dy = -1; break;
      case ConsoleKey.DownArrow when dy == 0: dx = 0; dy = 1; break;
      case ConsoleKey.LeftArrow when dx == 0: dx = -1; dy = 0; break;
      case ConsoleKey.RightArrow when dx == 0: dx = 1; dy = 0; break;
    }
  }

  public Point CalculateNextHead()
  {
    return new Point(Head.X + dx, Head.Y + dy);
  }

  public void Move()
  {
    Point newHead = CalculateNextHead();
    Body.Insert(0, newHead);
    Body.RemoveAt(Body.Count - 1);
  }

  public void Grow()
  {
    Point newHead = CalculateNextHead();
    Body.Insert(0, newHead);
  }

  public bool CheckCollision(int width, int height)
  {
    // Wall collision
    if (Head.X <= 0 || Head.Y <= 0 || Head.X >= width || Head.Y >= height)
      return true;

    // Self-collision
    for (int i = 1; i < Body.Count; i++)
    {
      if (Head.X == Body[i].X && Head.Y == Body[i].Y)
        return true;
    }

    return false;
  }
}

public class Fruit
{
  public static string[] fruits = {
    "🍎", // Red Apple
    "🍏", // Green Apple
    "🍐", // Pear
    "🍊", // Tangerine
    "🍋", // Lemon
    "🍌", // Banana
    "🍉", // Watermelon
    "🍇", // Grapes
    "🍓", // Strawberry
    "🫐", // Blueberries
    "🥭", // Mango
    "🍍", // Pineapple
    "🥥", // Coconut
    "🥝", // Kiwi Fruit
    "🍒", // Cherries
    "🍑"  // Peach
};
  public static Point Generate(int width, int height, List<Point> snakeBody)
  {
    Random random = new Random();
    Point fruit;
    do
    {
      fruit = new Point(random.Next(1, width), random.Next(1, height));
    } while (snakeBody.Exists(p => p.X == fruit.X && p.Y == fruit.Y));

    return fruit;
  }
}
