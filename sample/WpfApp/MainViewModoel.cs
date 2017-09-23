using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (field.Equals(value))
                return;
            field = value;
            NotifyPropertyChanged(propertyName);
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModoel : ViewModel
    {
        decimal _value;
        public decimal Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }
    }
}
