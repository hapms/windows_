using System.Windows;

namespace Hapoom.Windows.Controls
{
    public class NumericUpDownValueChangedEventArgs : RoutedEventArgs
    {
        public NumericUpDownValueChangedEventArgs(RoutedEvent routedEvent, decimal value)
        {
            RoutedEvent = routedEvent;
            Value       = value;
        }

        public decimal Value { get; private set; }
    }
}
