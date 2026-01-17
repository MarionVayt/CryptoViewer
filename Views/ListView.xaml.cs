using System.Windows.Controls;
using System.Windows.Input;
using CryptoViewer.Models;
using CryptoViewer.ViewModels;

namespace CryptoViewer.Views;

public partial class ListView : Page
{
    public ListView()
    {
        InitializeComponent();
    }
    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DataGrid grid = (DataGrid)sender;
        CoinModel selectedCoin = (CoinModel)grid.SelectedItem;
        if (selectedCoin == null) return;
        NavigationService.Navigate(new DetailView(selectedCoin));
    }
    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        
        if (DataContext is MainViewModel vm)
        {
            vm.FilterCoins(text);
        }
    }
}