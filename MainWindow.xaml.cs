using System.Windows;
using CryptoViewer.ViewModels;
using CryptoViewer.Views; 

namespace CryptoViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var vm = new MainViewModel();
            
            var listPage = new ListView();
            
            listPage.DataContext = vm;
            
            MainFrame.Navigate(listPage);
        }
    }
}