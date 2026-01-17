using System.Windows;
using System.Windows.Controls;
using CryptoViewer.Models;

namespace CryptoViewer.Views;

public partial class DetailView : Page
{
    public DetailView(CoinModel coin)
    {
        InitializeComponent();

        DataContext = coin;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}