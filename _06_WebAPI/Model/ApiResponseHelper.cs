namespace WebAPI.Models;

public static class ApiResponseHelper
{
  public static ApiResponse<T> Success<T>(T data) => new() { Success = true, Data = data };
  public static ApiResponse<T> Failure<T>(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
}