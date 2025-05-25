namespace WebAPI.Models;

public class UserPreference
{
  public Guid? Id { get; set; }
  public string? Theme { get; set; }
  public string? Language { get; set; }
  public string? FontSize { get; set; }
  public bool? NotificationsEnabled { get; set; }
}