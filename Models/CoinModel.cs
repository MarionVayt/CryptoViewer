using System.Text.Json.Serialization;

namespace CryptoViewer.Models;

public class CoinModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("image")]
    public string ImageUrl { get; set; }
    
    [JsonPropertyName("current_price")]
    public decimal? CurrentPrice { get; set; }
    
    [JsonPropertyName("market_cap_rank")]
    public int? Rank { get; set; }
    
    [JsonPropertyName("price_change_percentage_24h")]
    public double? PriceChangePercentage24H { get; set; }
}