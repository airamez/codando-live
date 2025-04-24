/*
https://learn.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-9.0

Directory
- A static class for handling directories.
- Provides methods for creating, moving, deleting, and listing directories.
- Works with directory paths as strings rather than objects.
- Methods:
  - Directory.CreateDirectory(path) – Creates a new directory.
  - Directory.Exists(path) – Checks if a directory exists.
  - Directory.GetFiles(path) – Gets an array of file names in a directory.
  - Directory.GetDirectories(path) – Gets an array of subdirectories.
  - Directory.Delete(path, recursive: true) – Deletes a directory.

DirectoryInfo
- A non-static class that provides detailed information and operations on directories.
- Methods & Properties:
  - DirectoryInfo di = new DirectoryInfo(path);
  - di.Exists – Checks if the directory exists.
  - di.CreationTime – Gets the directory creation time.
  - di.GetFiles() – Gets an array of FileInfo objects for files in the directory.
  - di.GetDirectories() – Gets an array of DirectoryInfo objects for subdirectories.
  - di.Delete(true) – Deletes the directory and all contents.

File
- A static class used for common file operations.
- Provides methods to create, copy, delete, move, and read/write files.
- Works with file paths as strings rather than objects.
- Methods:
  - File.Create(path) – Creates a new file.
  - File.Exists(path) – Checks if a file exists.
  - File.ReadAllText(path) – Reads all text from a file.
  - File.WriteAllText(path, text) – Writes text to a file.
  - File.Delete(path) – Deletes a file.

FileInfo
- A non-static class that provides detailed information and operations on a file.
- Methods & Properties:
  - FileInfo fi = new FileInfo(path);
  - fi.Length – Gets the file size.
  - fi.Extension – Gets the file extension.
  - fi.Exists – Checks if the file exists.
  - fi.Delete() – Deletes the file.
  - fi.CopyTo(destinationPath) – Copies the file.
*/
using System;
using System.IO;

namespace DotNetAPI;

public class DirectoryAndFileApp
{
  public const bool PRINT_FILES_CONTENT = true;
  public static void Main(string[] args)
  {
    string baseFolder = Directory.GetCurrentDirectory() + "\\CSharp";
    if (!Directory.Exists(baseFolder))
    {
      Console.Write("Directory: ");
      baseFolder = Console.ReadLine();
    }
    Console.WriteLine($"Target Folder: {baseFolder}");
    DirectoryInfo dir = new DirectoryInfo(baseFolder);
    PrintDirectory(dir, 0);
  }

  static void PrintDirectory(DirectoryInfo dir, int indentLevel)
  {
    if (dir.Name == "bin" || dir.Name == "obj" || dir.Name == "TestResults")
    {
      return;
    }
    string indent = new string(' ', indentLevel * 2);
    try
    {
      Console.WriteLine($"{indent} [DIR]: {dir.Name}");
      foreach (var file in dir.GetFiles("*.cs"))
      {
        Console.WriteLine($"{indent}   [FILE]: {file.Name}; Size: {file.Length} bytes");
        if (PRINT_FILES_CONTENT)
        {
          Console.WriteLine(File.ReadAllText(file.FullName));
        }
      }
      foreach (var subDir in dir.GetDirectories())
      {
        PrintDirectory(subDir, indentLevel + 1);
      }
    }
    catch (IOException ex)
    {
      Console.WriteLine(ex);
    }
  }
}