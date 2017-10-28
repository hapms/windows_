using System.Windows;
using System.Windows.Controls;
using Hapoom.Windows;

namespace WpfApp
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b     = sender as Button;
            var t     = (b.Content?.ToString() == "Light") ? Themes.Light : Themes.Dark;
            ThemeSelector.Instance.Theme = t;
            b.Content = (t == Themes.Light) ? "Dark" : "Light";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
