namespace WebAPI.Models;

public class ApiResponse<T>
{
  public bool Success { get; set; }
  public T? Data { get; set; }
  public string? ErrorMessage { get; set; }
  public int? Version { get; set; }
  public List<string> Errors { get; set; } = new List<string>();
}