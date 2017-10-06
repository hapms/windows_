using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Hapoom.Windows
{
    public class WindowBase : Window
    {
        ResourceDictionary _dark;
        ResourceDictionary _light;
        CommandBinding[]   _commandBindings;

        public WindowBase()
        {
            _commandBindings = new [] { 
                new CommandBinding(SystemCommands.MinimizeWindowCommand, (sender, e) => { SystemCommands.MinimizeWindow(this); }),
                new CommandBinding(SystemCommands.MaximizeWindowCommand, (sender, e) => { SystemCommands.MaximizeWindow(this); }),
                new CommandBinding(SystemCommands.RestoreWindowCommand , (sender, e) => { SystemCommands.RestoreWindow (this); }),
                new CommandBinding(SystemCommands.CloseWindowCommand   , (sender, e) => { SystemCommands.CloseWindow   (this); }),
            }; 
            CommandBindings.AddRange(_commandBindings);

            _dark  = (ResourceDictionary)Application.LoadComponent(new Uri(@"/Hapoom.Windows;component/Themes/_Dark.xaml" , UriKind.Relative));
            _light = (ResourceDictionary)Application.LoadComponent(new Uri(@"/Hapoom.Windows;component/Themes/_Light.xaml", UriKind.Relative));
        }

        protected void ChangeBlackTheme()
        {
            ChangeTheme(_dark);
        }

        protected void ChangeWhiteTheme()
        {
            ChangeTheme(_light);
        }

        private void ChangeTheme(ResourceDictionary resourceDictionary)
        {
            foreach (var key in resourceDictionary.Keys)
            {
                Resources[key] = resourceDictionary[key];
            }
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaxHeight = 1880; //MonitorInfo.ScreenOf(window).WorkingArea.Height + 12;
                Padding   = new Thickness(0);
            }
            else
            {
                MaxHeight = double.PositiveInfinity;
                Padding   = new Thickness(5);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            foreach (var b in _commandBindings)
                CommandBindings.Remove(b);
        }
    }
}
