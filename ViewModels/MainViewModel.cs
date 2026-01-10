using CryptoViewer.Services;
using CryptoViewer.Models;
using System.Collections.ObjectModel;

namespace CryptoViewer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly CoinService _coinService;
    
    public ObservableCollection<CoinModel> Coins { get; set; }

    public MainViewModel()
    {
        _coinService = new CoinService();
        Coins = new ObservableCollection<CoinModel>();

        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        var coinsList = await _coinService.GetTopCoins();
        
        Coins.Clear();
        foreach (var coin in coinsList)
        {
            Coins.Add(coin);
        }
    }
}