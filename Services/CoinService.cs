using System.Net.Http;
using System.Text.Json;
using CryptoViewer.Models;

namespace CryptoViewer.Services;

public class CoinService
{
    private readonly HttpClient _httpClient;

    public CoinService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "CryptoViewer/1.0");
    }

    public async Task<List<CoinModel>> GetTopCoinsAsync()
    {
        string url = "coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1&sparkline=false";

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var coins = JsonSerializer.Deserialize<List<CoinModel>>(json, options);
            return coins ?? new List<CoinModel>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ПОМИЛКА API: {ex.Message}");
            return new List<CoinModel>();
        }
    }
}