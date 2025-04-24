using System;
/*
# The static keyword is used to declare a member that belongs
  to the class itself rather than to a specific object.
# A static class is a class that cannot be instantiated and
  can only contain static members.
# A static constructor is a constructor that is called only
  once when the class is first loaded into memory.

# Class Content
  # Create an example to show it
    # Object instances counter
  # Show the examples:
    # Console.Write
    # Math class
*/

namespace OurCompany.LearnCoding.OOP.Static;

public class StaticApp
{
  public static void Main(string[] args)
  {
    Console.WriteLine($"Player Count: {Player.PlayerCount}");
    Player player1 = new Player("Player 1");
    Player player2 = new Player("Player 2");
    Player player3 = new Player("Player 3");
    Player player4 = new Player("Player 4");
    Player player5 = new Player("Player 5");
    Console.WriteLine($"Player Count: {Player.PlayerCount}");

    int maximum = Math.Max(7, 45);
  }
}

public class Player
{
  private static int _playerCount;
  public static int PlayerCount
  {
    get
    {
      return _playerCount;
    }
  }

  public string Name { get; set; }

  public Player(string name)
  {
    Name = name;
    _playerCount++;
  }

  static Player()
  {
    _playerCount = 0;
  }
}