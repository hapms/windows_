using System;
using System.Collections.Generic;
using System.Windows;

namespace Hapoom.Windows
{
    public class ThemeDictionary : Dictionary<Themes, ResourceDictionary>
    {
        public ThemeDictionary()
        {
            Add(Themes.Dark , (ResourceDictionary)Application.LoadComponent(new Uri(@"/Hapoom.Windows;component/Themes/Dark/Index.xaml"  , UriKind.Relative)));
            Add(Themes.Light, (ResourceDictionary)Application.LoadComponent(new Uri(@"/Hapoom.Windows;component/Themes/Light/Index.xaml" , UriKind.Relative)));
        }
    }
}
