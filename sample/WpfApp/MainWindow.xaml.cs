using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hapoom.Windows;

namespace WpfApp
{
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                if(fontFamily.Source.ToLower().StartsWith("na"))
                    Console.WriteLine(fontFamily);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb     = sender             as ComboBox;
            var item    = cmb ?.SelectedItem as ComboBoxItem;
            //var content = item?.Content?.ToString();
            //if (content == "Dark")
            //    Theme = Themes.Dark;
            //else
            //if (content == "Light")
            //    Theme = Themes.Light;
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                    Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //if (MessageBoxResult.Yes != MessageBox.Show(
            //        "text", 
            //        "title", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No))
            //{
            //    e.Cancel = true;
            //}
            //var w = new ModalWindow {
            //    Owner = this,
            //    WindowStartupLocation = WindowStartupLocation.CenterOwner
            //};
            //if (w.ShowDialog() != true)
            //{
            //    e.Cancel = true;
            //}
            base.OnClosing(e);
        }
    }
}
