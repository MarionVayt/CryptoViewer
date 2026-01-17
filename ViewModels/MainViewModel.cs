using CryptoViewer.Services;
using CryptoViewer.Models;
using System.Collections.ObjectModel;

namespace CryptoViewer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly CoinService _coinService;
    
    private List<CoinModel> _allCoins; 
    
    public ObservableCollection<CoinModel> Coins { get; set; }

    public MainViewModel()
    {
        _coinService = new CoinService();
        Coins = new ObservableCollection<CoinModel>();
        _allCoins = new List<CoinModel>();
            
        LoadDataAsync(); 
    }

    private async void LoadDataAsync()
    {
        var coinsList = await _coinService.GetTopCoinsAsync();
        
        _allCoins = coinsList;
        
        Coins.Clear();
        foreach (var coin in coinsList)
        {
            Coins.Add(coin);
        }
    }
    
    public void FilterCoins(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            Coins.Clear();
            foreach (var coin in _allCoins) Coins.Add(coin);
            return;
        }
        var filtered = _allCoins.Where(c => c.Name.ToLower().Contains(searchText.ToLower()) || 
                                            c.Symbol.ToLower().Contains(searchText.ToLower()));
        
        Coins.Clear();
        foreach (var coin in filtered)
        {
            Coins.Add(coin);
        }
    }
}