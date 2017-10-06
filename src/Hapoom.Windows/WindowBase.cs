using System.Windows;
using System.Windows.Input;

namespace Hapoom.Windows
{
    public class WindowBase : Window
    {
        public WindowBase()
        {
            CommandBindings.AddRange(new[] {
                new CommandBinding(SystemCommands.MinimizeWindowCommand, (sender, e) => { SystemCommands.MinimizeWindow(this); }),
                new CommandBinding(SystemCommands.MaximizeWindowCommand, (sender, e) => { SystemCommands.MaximizeWindow(this); }),
                new CommandBinding(SystemCommands.RestoreWindowCommand , (sender, e) => { SystemCommands.RestoreWindow (this); }),
                new CommandBinding(SystemCommands.CloseWindowCommand   , (sender, e) => { SystemCommands.CloseWindow   (this); }),
            });
        }
    }
}
