using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Async;

public class WebExplorerApp
{
  public static async Task Main(string[] args)
  {
    WebExplorer webExplorer = new WebExplorer(3);
    Stopwatch stopwatch = Stopwatch.StartNew();
    await webExplorer.Explorer("https://raw.githubusercontent.com/airamez/codando-live/refs/heads/main/README.md");
    // await webExplorer.Explorer("https://github.com/airamez/codando-live");
    //await webExplorer.Explorer("https://google.com");
    stopwatch.Stop();
    Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds / 1000} seconds");
  }
}

public class WebExplorer
{
  private ConcurrentDictionary<string, bool> Visited;
  private int Count;
  private int LevelLimit;

  public WebExplorer(int levelLimit)
  {
    LevelLimit = levelLimit;
    Count = 0;
    Visited = new ConcurrentDictionary<string, bool>();
  }

  public async Task Explorer(string url, int level = 0)
  {
    if (level > LevelLimit || Visited.ContainsKey(url))
    {
      return;
    }
    Console.WriteLine($"{Count++}[{level}]: {url}");
    string content = await GetUrlContent(url);
    if (string.IsNullOrWhiteSpace(content))
    {
      return;
    }
    string pattern = @"https?://[^\s""<>]+";
    MatchCollection matches = Regex.Matches(content, pattern);
    List<Task> tasks = new List<Task>();
    foreach (Match match in matches)
    {
      tasks.Add(Explorer(match.Value, level + 1));
    }
    await Task.WhenAll(tasks);
  }

  private async Task<string> GetUrlContent(string requestUri)
  {
    using (HttpClient client = new HttpClient())
    {
      try
      {
        HttpResponseMessage response = await client.GetAsync(requestUri);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
          return string.Empty;
        }
        if (response.Content.Headers.ContentType != null &&
            (response.Content.Headers.ContentType.MediaType.StartsWith("text") ||
             response.Content.Headers.ContentType.MediaType.Contains("json")))
        {
          return await response.Content.ReadAsStringAsync();
        }
        else
        {
          return string.Empty;
        }
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}
