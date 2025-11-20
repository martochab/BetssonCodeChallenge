using System.Net.Http.Json;

namespace Betsson.OnlineWallets.ApiTests.Helpers;

public class ApiClient
{
    private readonly HttpClient _client;

    public ApiClient(string baseUrl)
    {
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        return await _client.GetFromJsonAsync<T>(endpoint);
    }

    public async Task<T?> PostAsync<T>(string endpoint, object body)
    {
        var response = await _client.PostAsJsonAsync(endpoint, body);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<HttpResponseMessage> PostRawAsync(string endpoint, object body)
    {
        return await _client.PostAsJsonAsync(endpoint, body);
    }
}