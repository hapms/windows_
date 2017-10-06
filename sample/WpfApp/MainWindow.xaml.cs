using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Hapoom.Windows;

namespace WpfApp
{
    public partial class MainWindow : WindowBase
    {
        MainViewModoel _vm = new MainViewModoel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            _vm.Title = "하아푸움 hapoom-s.tistory.com";
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ChangeBlackTheme();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ChangeWhiteTheme();
        }
    }
}
