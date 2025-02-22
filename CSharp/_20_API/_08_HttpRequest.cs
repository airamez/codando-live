/*
- HTTP requests are the foundation of the web. 
  They allow clients (e.g., web browsers) to communicate with servers to fetch resources,
  submit data, and more. In C#, you can make HTTP requests using the HttpClient class 
  from the System.Net.Http namespace.
- HTTP Methods: The main HTTP methods are:
  - GET: retrieve data
  - POST: send data
  - PUT: update data
  - DELETE: remove data
  - PATCH: partial update data
  - OPTIONS: check for communication options
- Request URI: The URL that specifies the resource you're interacting with.
- Headers: Key-value pairs that provide additional information about the request
  or response, such as content type, authorization, etc.
- Body: Data sent with the request, typically used with POST or PUT methods.
- Status Codes: Indicate the result of the HTTP request:
  - 200: OK
  - 404: Not Found
  - 500: Internal Server Error
  - https://www.w3schools.com/tags/ref_httpmessages.asp
*/
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetAPI;

public class HttpRequestApp
{
  static async Task Main(string[] args)
  {
    // GET
    using (HttpClient client = new HttpClient())
    {
      try
      {
        // Set the request URI
        string requestUri = "http://jsonplaceholder.typicode.com/posts/1";
        // Send the GET request
        HttpResponseMessage response = await client.GetAsync(requestUri);
        // Ensure the response is successful
        response.EnsureSuccessStatusCode();
        // Read the response content
        string responseBody = await response.Content.ReadAsStringAsync();
        // Output the response
        Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"Request error: {e.Message}");
      }
    }

    // POST
    using (HttpClient client = new HttpClient())
    {
      try
      {
        // Set the request URI
        string requestUri = "https://jsonplaceholder.typicode.com/posts";
        // Create the data to send
        var postData = new
        {
          title = "foo",
          body = "bar",
          userId = 1
        };
        // Serialize the data to JSON
        string json = JsonSerializer.Serialize(postData);
        // Create the content to send
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        // Send the POST request
        HttpResponseMessage response = await client.PostAsync(requestUri, content);
        // Ensure the response is successful
        response.EnsureSuccessStatusCode();
        // Read the response content
        string responseBody = await response.Content.ReadAsStringAsync();
        // Output the response
        Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"Request error: {e.Message}");
      }
    }
  }
}