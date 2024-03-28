using CtypyoApp.Models.API;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


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

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border borderNextDataGrid)
            {
                borderNextDataGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7163ba"));
                borderNextDataGrid.VerticalAlignment = VerticalAlignment.Center;
                borderNextDataGrid.HorizontalAlignment = HorizontalAlignment.Center;
                borderNextDataGrid.Width = 45;
                borderNextDataGrid.Height = 45;
                if(borderNextDataGrid.Child is Label labelBorderNext)
                {
                    labelBorderNext.Content = "Next";
                    labelBorderNext.FontSize = 14;
                    labelBorderNext.VerticalAlignment = VerticalAlignment.Center;
                    labelBorderNext.HorizontalAlignment = HorizontalAlignment.Center;
                }
            } 
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border borderNextDataGrid)
            {
                borderNextDataGrid.Background = Brushes.Transparent;
                if (borderNextDataGrid.Child is Label labelBorderNext)
                {
                    labelBorderNext.Content = "Open";
                    labelBorderNext.FontSize = 12;
                }
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            if (e.Delta > 0)
            {
                scroll.LineUp();
            }
            else
            {
                scroll.LineDown();
            }
            e.Handled=true;
        }
    }
}