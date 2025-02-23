/*
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/
- What are Delegates?
  A delegate is a type that represents references to methods with a specific parameter list and return type.
  Delegates are used to pass methods as arguments to other methods, enabling flexible and dynamic method execution.
- Key Points:
  - Type Safety: Delegates are type-safe, meaning they ensure that the method signature matches the delegate signature.
  - Multicasting: Delegates can point to multiple methods, allowing them to be used for event handling.
  - Callbacks: Delegates are used to define callback methods.
  - Anonymous Methods & Lambdas: Delegates are foundational to using anonymous methods and lambda expressions.
  - Delegates in C# are a fundamental concept for implementing event-driven programming and callback methods
- Sintaxe
  public delegate RETURN_TYPE DELEGATE_NAME(LIST_OF_PARAMETERS)
*/
using System;

namespace Advanced;

public class DelegateApp
{
  // Declare a delegate type
  public delegate void GreetDelegate(string name);

  public static void Main(string[] args)
  {
    // Instantiate the delegate
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
    // Invoke the delegate
    greetDelegate(name);
  }

  // Greeting methods matching the delegate signature
  static void FormalGreeting(string name) => Console.WriteLine($"Good day, {name}. It is a pleasure to meet you.");
  static void CasualGreeting(string name) => Console.WriteLine($"Hey {name}, what's up?");
  static void ExcitedGreeting(string name) => Console.WriteLine($"{name}! Great to see you!");
}