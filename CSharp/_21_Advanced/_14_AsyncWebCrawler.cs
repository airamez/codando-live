using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Async;

public class WebExplorerApp
{
  public static async Task Main(string[] args)
  {
    WebExplorer webExplorer = new WebExplorer();
    Stopwatch stopwatch = Stopwatch.StartNew();
    await webExplorer.Explore("https://raw.githubusercontent.com/airamez/codando-live/refs/heads/main/README.md", 1);
    //await webExplorer.Explore("https://github.com/airamez/codando-live", 2);

    stopwatch.Stop();
    Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds / 1000} seconds");
  }
}

public class WebExplorer
{
  private ConcurrentDictionary<string, bool> VisitedUrls { set; get; }
  private int DepthLimit { set; get; }

  public WebExplorer()
  {
  }

  public async Task Explore(string url, int depth)
  {
    DepthLimit = depth;
    VisitedUrls = new ConcurrentDictionary<string, bool>();
    await ExploreTask(url, 0);
    Console.WriteLine($"Exploration completed: {VisitedUrls.Count} pages explored!!!");
  }

  public async Task ExploreTask(string url, int depth)
  {
    if (depth > DepthLimit || VisitedUrls.ContainsKey(url))
    {
      return;
    }
    VisitedUrls[url] = true;
    Console.WriteLine($"[{VisitedUrls.Count}:{depth}]={url}");
    string content = await GetUrlContent(url);
    if (string.IsNullOrWhiteSpace(content))
    {
      return;
    }
    string UrlPattern = @"https?://[^\s""<>]+";
    MatchCollection matches = Regex.Matches(content, UrlPattern);
    var tasks = new List<Task>();
    foreach (Match match in matches)
    {
      tasks.Add(ExploreTask(match.Value, depth + 1));
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
        if (response.StatusCode == System.Net.HttpStatusCode.OK &&
            response.Content.Headers.ContentType != null &&
            response.Content.Headers.ContentType.MediaType.StartsWith("text"))
        {
          return await response.Content.ReadAsStringAsync();
        }
      }
      catch { }
      return string.Empty;
    }
  }
}
