using System.Windows;
using System.Windows.Input;

namespace Hapoom.Windows
{
    public class ThemeSelector : DependencyObject
    {
        static ThemeDictionary _resources = new ThemeDictionary();

        private ThemeSelector() { }

        public static ThemeSelector Instance { get; } = new ThemeSelector();

        #region ThemeProperty
        public static readonly DependencyProperty ThemeProperty
            = DependencyProperty.Register("Theme",
                                           typeof(Themes), 
                                           typeof(ThemeSelector),
                                           new PropertyMetadata(Themes.Light, OnThemePropertyChanged));

        public static Themes GetTheme(DependencyObject d)
        {
            return (Themes)d.GetValue(ThemeProperty);
        }
        public static void SetTheme(DependencyObject d, Themes value)
        {
            d.SetValue(ThemeProperty, value);
        }

        private static void OnThemePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = (ThemeSelector)d;
            t.OnThemeChanged((Themes)e.NewValue);
        }

        protected virtual void OnThemeChanged(Themes theme)
        {
            foreach (Window w in Application.Current.Windows)
            {
                Apply(w);
            }
        }

        public Themes Theme
        {
            get { return GetTheme(this); }
            set { SetTheme(this, value); }
        }
        #endregion

        public ICommand ToggleThemeCommand { get; set; } = new ToggleThemeCommand();

        public void Apply(Window w)
        {
            var resources = _resources[Theme];
            foreach (var key in ResourceKeys.All)
            {
                w.Resources[key] = resources[key];
            }
        }
    }
}