using System;

/*
# An interface is a contract that specifies a set of methods
  and properties that a class must implement.
# Interfaces are used to achieve abstraction by allowing to write
  code that is independent of any specific implementation.
# Interfaces are declared using the interface keyword,
  followed by the name of the interface and a set of
  method and property signatures.
# A class can implement one or more interfaces by providing
  an implementation for each method and property in the interface.
# A class can inherit from a base class and implement one or
  more interfaces at the same time.
# Interfaces can be used to define common functionality across
  multiple classes, which can help reduce code duplication and
  improve maintainability.
# Interfaces can be used as Types

# Class Content
  # Theory
  # Explain the classes and interfaces
  # Show the entire program
  # Run the game
  # Change the game a little to execute multiple times and 
    count victories
*/

public class InterfacesApp
{
  public static void Main(string[] args)
  {
    int countWins = 0;
    for (int i = 0; i < 1000; i++)
    {
      if (GameTurn())
      {
        countWins++;
      }
    }
    Console.WriteLine($"Wins: {countWins}");
    Console.WriteLine($"Loses: {100 - countWins}");
  }

  private static bool GameTurn()
  {
    GameEntity[] entities = new GameEntity[5];
    entities[0] = new Player("Jose", 100, 10);
    entities[1] = new Enemy("Bat", 10, 2);
    entities[2] = new Enemy("Vampire", 30, 15);
    entities[3] = new Enemy("Mummy", 50, 5);
    entities[4] = new Enemy("Werewolf", 35, 10);

    Random random = new Random();
    int turn = 0;
    Player player = (Player)entities[0];
    int aliveEnemiesCount = entities.Length - 1;
    while (player.IsAlive && aliveEnemiesCount > 0)
    {
      turn++;
      Console.WriteLine("".PadLeft(100, '-'));
      Console.WriteLine($"Turn: {turn}");
      aliveEnemiesCount = entities.Length - 1;
      for (int i = 1; i < entities.Length; i++)
      {
        Enemy enemy = (Enemy)entities[i];
        if (!enemy.IsAlive)
        {
          aliveEnemiesCount--;
        }
        else
        {
          enemy.Log();
          enemy.TakeDamage(random.Next(0, player.Damage + 1));
          if (enemy.IsAlive)
          {
            player.Log();
            player.TakeDamage(random.Next(0, enemy.Damage + 1));
            if (!player.IsAlive)
            {
              break;
            }
          }
        }
      }
    }
    Console.WriteLine($"Game turns: {turn}");
    if (player.HP > 0)
    {
      Console.WriteLine("Player won!");
    }
    else
    {
      Console.WriteLine("Player lost!");
    }
    player.Log();
    Console.WriteLine("".PadLeft(100, '='));
    Console.WriteLine("Final Log");
    for (int i = 0; i < entities.Length; i++)
    {
      ILogger logger = entities[i];
      logger.Log();
    }
    return player.IsAlive;
  }
}

interface ILogger
{
  void Log();
}

interface IDamageable
{
  void TakeDamage(int value);
}

public class GameEntity : ILogger, IDamageable
{
  public int HP { get; set; }
  public int Damage { get; set; }
  public bool IsAlive { get => HP > 0; }

  public GameEntity(int hp, int damage)
  {
    HP = hp;
    Damage = damage;
  }

  public virtual void TakeDamage(int damage)
  {
    HP -= damage;
    if (HP < 0)
    {
      HP = 0;
    }
  }

  public virtual void Log()
  {
    Console.Write($"[HP:{HP}]");
    if (IsAlive)
    {
      Console.WriteLine("[Alive]");
    }
    else
    {
      Console.WriteLine("[Dead]");
    }
  }
}

public class Player : GameEntity
{
  public string Name { get; set; }

  public Player(string name, int hp, int damage)
  : base(hp, damage)
  {
    Name = name;
  }

  public override void TakeDamage(int damage)
  {
    base.TakeDamage(damage);
    Console.WriteLine($"[Combat] Player: {Name}; took {damage} damage; HP: {HP}");
    Log();
  }

  public override void Log()
  {
    Console.Write($"Player: {Name}; ");
    base.Log();
  }
}

public class Enemy : GameEntity
{
  public string Type { get; set; }

  public Enemy(string type, int hp, int damage)
  : base(hp, damage)
  {
    Type = type;
  }

  public override void TakeDamage(int damage)
  {
    base.TakeDamage(damage);
    Console.WriteLine($"[Combat] Enemy: {Type}; took {damage} damage; HP: {HP}");
    Log();
  }

  public override void Log()
  {
    Console.Write($"Enemy: {Type}; ");
    base.Log();
  }
}