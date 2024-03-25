using CtypyoApp.Models.API;
using FontAwesome.WPF;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using static CtypyoApp.Models.API.CoinGeckoApi;


namespace CryptoUI
{
    public partial class MainWindow : Window
    {
        private CoinGeckoApi coinGeckoAPI = new CoinGeckoApi();
        public MainWindow()
        {
            InitializeComponent();

        }

        
        private void FullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            FullScreenState();
        }

        private void ScreenClose_Click(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void ScreenStateAndDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                FullScreenState();
            }
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем список топ N криптовалют
                List<CryptoCurrency> topCurrencies = await coinGeckoAPI.GetTopNCurrenciesAsync(250, 1);

                // Привязываем список к DataGrid
                DataGrid.ItemsSource = topCurrencies;
            }
            catch (Exception ex)
            {
                // Обработка возможных ошибок, например, вывод в консоль
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Функция для полного экрана
        public void FullScreenState()
        {
            if (WindowState == WindowState.Maximized)
            {
                BorderScreen.CornerRadius = new CornerRadius(30);
                WindowState = WindowState.Normal;
            }
            else
            {
                BorderScreen.CornerRadius = new CornerRadius(0);
                WindowState = WindowState.Maximized;
            }
        }
    }
}