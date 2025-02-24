using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advanced;

public class WebCrawlerApp
{
  public static async Task Main(string[] args)
  {
    WebCrawler webCrawler = new WebCrawler(2);

    Stopwatch stopwatch = Stopwatch.StartNew();

    await webCrawler.Crawls("https://en.wikipedia.org/wiki/Main_Page", true);
    //await webCrawler.Crawls("https://en.wikipedia.org/wiki/Main_Page", false);

    stopwatch.Stop();
    Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds / 1000} seconds");
  }
}

public class WebCrawler
{
  private ConcurrentDictionary<string, bool> Visited;
  private int Count;
  private int LevelLimit;

  public WebCrawler(int levelLimit)
  {
    LevelLimit = levelLimit;
    Count = 0;
    Visited = new ConcurrentDictionary<string, bool>();
  }

  public async Task Crawls(string url, bool async, int level = 1)
  {
    if (level > LevelLimit || !Visited.TryAdd(url, true))
    {
      return;
    }

    string content = await GetUrlContent(url);
    if (string.IsNullOrWhiteSpace(content))
    {
      return;
    }

    Console.WriteLine($"{Count++}[{level}]: {url}");
    string pattern = @"https?://[^\s""<>]+";
    MatchCollection matches = Regex.Matches(content, pattern);

    if (async)
    {
      List<Task> tasks = new List<Task>();
      foreach (Match match in matches)
      {
        tasks.Add(Crawls(match.Value, async, level + 1));
      }
      await Task.WhenAll(tasks);
    }
    else
    {
      foreach (Match match in matches)
      {
        await Crawls(match.Value, async, level + 1);
      }
    }
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
