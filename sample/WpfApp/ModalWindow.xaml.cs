using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// ModalWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModalWindow : Window
    {
        public ModalWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
