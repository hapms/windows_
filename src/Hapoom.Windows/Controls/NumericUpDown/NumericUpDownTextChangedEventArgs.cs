using System.Windows;

namespace Hapoom.Windows.Controls
{
    public class NumericUpDownTextChangedEventArgs : RoutedEventArgs
    {
        public NumericUpDownTextChangedEventArgs(RoutedEvent routedEvent, string value)
        {
            RoutedEvent = routedEvent;
            Value       = value;
        }

        public string Value { get; private set; }
    }
}
