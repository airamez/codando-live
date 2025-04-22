using System;

/*
  - A console application can be executed directly
  - The Main method is the entry point
  - The string[] parameter represents the values passed at the command line calling the console application
  - White spaces characters define each parameter value
  - If one paremeter requires multiple words it has to be inside double quotes. e.g "this is one parameter"
  - The string[] paramter will have each parameter value in sequence order
  - Build a Solution/Project:
    dotnet build [solution/project name]
  - Run (Execute) a Solution/Project:
    dotnet run
  OBS: If there is only one project or solution in the current folder the solution/project name can be omitted
  - Remember that the [project name].csproj indicate which class/program is the start point
    in the <StartupObject>CLASS_NAME</StartupObject> section
  Examples:
  dotnet build IntroToCoding.csproj
  dotnet run param1 param2 param3 param4 "parameter five5"
  */

public class _01_Args
{
  public static void Main(string[] arguments)
  {
    Console.WriteLine($"Arguments #: {arguments.Length}");
    for (int i = 0; i < arguments.Length; i++)
    {
      Console.WriteLine($"Parameter[{i}]:{arguments[i]}");
    }
  }
}