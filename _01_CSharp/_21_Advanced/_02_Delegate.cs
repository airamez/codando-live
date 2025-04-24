/*
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
- What are Delegates?
  A delegate is a type that represents references to methods with a specific parameter list and return type.
  Delegates are used to pass methods as arguments to other methods, enabling flexible and dynamic method execution.
- Key Points:
  - Type Safety: Delegates are type-safe, meaning they ensure that the method signature matches the delegate signature.
  - Multicasting: Delegates can point to multiple methods, allowing them to be used for event handling.
    Operatos += -=
  - Delegates are a fundamental concept for implementing event-driven programming and callback methods
- Sintaxe
  delegate RETURN_TYPE DELEGATE_NAME(LIST_OF_PARAMETERS)
*/
using System;

namespace Advanced;

public class DelegateApp
{
  public static void Main(string[] args)
  {
    //Demo1();

    //Demo2();

    Demo3();
  }

  // Demo 1
  public delegate void GreetDelegate(string name);
  static void FormalGreeting(string name) => Console.WriteLine($"Good day, {name}. It is a pleasure to meet you.");
  static void CasualGreeting(string name) => Console.WriteLine($"Hey {name}, what's up?");
  static void ExcitedGreeting(string name) => Console.WriteLine($"{name}! Great to see you!");

  private static void Demo1()
  {
    GreetDelegate greetDelegate;
    Console.Write("Enter your name: ");
    string name = Console.ReadLine();
    Console.Write("Greating Type:\n  1: Formal;\n  2. Casual\n  3. Excited\nChoose greeting type: ");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
      case 1:
        greetDelegate = FormalGreeting;
        break;
      case 2:
        greetDelegate = CasualGreeting;
        break;
      case 3:
        greetDelegate = ExcitedGreeting;
        break;
      default:
        Console.WriteLine("Invalid choice, defaulting to formal.");
        greetDelegate = FormalGreeting;
        break;
    }
    greetDelegate(name);
  }

  // Demo 2
  public delegate void AttackDelegate(string target);
  static void SwordAttack(string target) => Console.WriteLine($"You slash {target} with a sword!");
  static void MagicAttack(string target) => Console.WriteLine($"You cast a fireball spell at {target}!");
  static void RangedAttack(string target) => Console.WriteLine($"You shoot an arrow at {target}!");

  private static void Demo2()
  {
    Console.Write("Enter your target: ");
    string target = Console.ReadLine();
    Console.Write("Which attacks you want to to use? S=Sword; M=Magic; R=Ranged: ");
    string selectedAttacks = Console.ReadLine().ToUpper();
    AttackDelegate attacks = null;
    if (selectedAttacks.Contains('S'))
    {
      attacks += SwordAttack;
    }
    if (selectedAttacks.Contains('M'))
    {
      attacks += MagicAttack;
    }
    if (selectedAttacks.Contains('R'))
    {
      attacks += RangedAttack;
    }
    attacks(target);
  }

  // Demo 3
  delegate void CharacterAction(string target);
  static void Heal(string target) => Console.WriteLine($"You heal {target} with a potion!");

  static void PerformAction(string target, CharacterAction action) => action(target);

  private static void Demo3()
  {
    string enemy = "Goblin";
    string ally = "Teammate";

    // Perform actions on enemy
    CharacterAction attacks = SwordAttack;
    attacks += MagicAttack;
    attacks += RangedAttack;
    PerformAction(enemy, attacks);

    // Perform actions on ally
    PerformAction(ally, Heal);
  }
}