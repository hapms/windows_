using System;
using System.Windows.Input;

namespace Hapoom.Windows
{
    public class ToggleThemeCommand : ICommand
    {
        int _themesLength;

        public ToggleThemeCommand()
        {
            _themesLength = Enum.GetNames(typeof(Themes)).Length;
        }

        public event EventHandler CanExecuteChanged
        {
            add    { ; }
            remove { ; }
        }

        public bool CanExecute(object parameter) 
            => true;

        public void Execute(object parameter)
        {
            var current = ((int)ThemeSelector.Instance.Theme) + 1;
            if (current > _themesLength - 1)
                current = 0;
            ThemeSelector.Instance.Theme = (Themes)current;
        }
    }
}
