namespace WpfApp
{
    public class MainViewModoel : ViewModel
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        decimal _value;
        public decimal Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }
}
