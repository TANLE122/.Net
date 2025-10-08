using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        var url = "https://jsonplaceholder.typicode.com/posts";

        // Dữ liệu JSON
        var json = "{\"title\":\"test\",\"body\":\"Hello World\",\"userId\":1}";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Kết quả POST:");
        Console.WriteLine(result);

        var url1 = "https://jsonplaceholder.typicode.com/posts/1";
        var json1 = "{\"id\":1,\"title\":\"updated\",\"body\":\"Hello Updated\",\"userId\":1}";
        var content1 = new StringContent(json1, Encoding.UTF8, "application/json");

        var response1 = await client.PutAsync(url1, content);

        string result1 = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Kết quả PUT:");
        Console.WriteLine(result);

    }
}
