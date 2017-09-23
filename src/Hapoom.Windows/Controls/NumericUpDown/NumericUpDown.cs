using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Hapoom.Windows.Controls
{
    [TemplatePart(Name = PART_TextBox   , Type = typeof(TextBox     ))]
    [TemplatePart(Name = PART_UpButton  , Type = typeof(RepeatButton))]
    [TemplatePart(Name = PART_DownButton, Type = typeof(RepeatButton))]
    public class NumericUpDown : Control
    {
        const string PART_UpButton   = "PART_UpButton";
        const string PART_DownButton = "PART_DownButton";
        const string PART_TextBox    = "PART_TextBox";

        RepeatButton _upButton;
        RepeatButton _downButton;
        TextBox      _textBox;

        public static readonly DependencyProperty DeltaProperty;
        public static readonly DependencyProperty ValueProperty;
        public static readonly DependencyProperty TextProperty;
        public static readonly RoutedEvent ValueChangedEvent;
        public static readonly RoutedEvent TextChangedEvent;

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control  = (NumericUpDown)d;
            var newValue = (decimal)e.NewValue;
            control.RaiseEvent(new NumericUpDownValueChangedEventArgs(ValueChangedEvent, newValue));
        }
        private static void TextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control  = (NumericUpDown)d;
            var newValue = (string)e.NewValue;
            control.RaiseEvent(new NumericUpDownTextChangedEventArgs(TextChangedEvent, newValue));
        }

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
            DeltaProperty     = DependencyProperty.Register("Delta", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(null));
            ValueProperty     = DependencyProperty.Register("Value", typeof(decimal), typeof(NumericUpDown), new FrameworkPropertyMetadata(0m  , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ValueChangedCallback));
            TextProperty      = DependencyProperty.Register("Text" , typeof(string ), typeof(NumericUpDown), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, TextChangedCallback));
            ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(EventHandler<NumericUpDownValueChangedEventArgs>), typeof(NumericUpDown));
            TextChangedEvent  = EventManager.RegisterRoutedEvent("TextChanged" , RoutingStrategy.Bubble, typeof(EventHandler<NumericUpDownTextChangedEventArgs> ), typeof(NumericUpDown));
        }

        public RepeatButton UpButton
        {
            get { return _upButton; }
            set
            {
                if (_upButton != null)
                    _upButton.Click -= new RoutedEventHandler(OnUpButtonClick);

                if (value == null)
                    return;

                _upButton = value;
                _upButton.Click += new RoutedEventHandler(OnUpButtonClick);
            }
        }

        public RepeatButton DownButton
        {
            get { return _downButton; }
            set
            {
                if (_downButton != null)
                    _downButton.Click -= new RoutedEventHandler(OnDownButtonClick);

                if (value == null)
                    return;

                _downButton = value;
                _downButton.Click += new RoutedEventHandler(OnDownButtonClick);
            }
        }

        public TextBox TextBox
        {
            get { return _textBox; }
            set
            {
                if (_textBox != null)
                {
                    _textBox.TextChanged -= OnTextBoxTextChanged;
                    _textBox.MouseWheel  -= OnTextBoxMouseWheel;
                }

                if (value == null)
                    return;

                _textBox      = value;
                _textBox.TextChanged += OnTextBoxTextChanged;
                _textBox.MouseWheel  += OnTextBoxMouseWheel;
                Up();Down();
            }
        }

        public decimal Delta
        {
            get { return (decimal)GetValue(DeltaProperty); }
            set { SetValue(DeltaProperty, value); }
        }

        public decimal Value
        {
            get { return (decimal)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public event EventHandler<NumericUpDownValueChangedEventArgs> ValueChanged
        {
            add    { AddHandler   (ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        public event EventHandler<NumericUpDownTextChangedEventArgs> TextChanged
        {
            add    { AddHandler   (TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        private void OnTextBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var text = (e.Source as TextBox)?.Text ?? "0";
            if (text.Length > 18)
                text = decimal.MaxValue.ToString();
            Text  = text;
            Value = decimal.Parse(Text);
        }
        private void OnTextBoxMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                Up();
            else
                Down();
        }
        private void OnUpButtonClick  (object sender, RoutedEventArgs e)
        {
            Up();
        }
        private void OnDownButtonClick(object sender, RoutedEventArgs e)
        {
            Down();
        }

        private void Up()   => SetValue(Value + Delta);
        private void Down() => SetValue(Value - Delta);

        private void SetValue(decimal value)
        {
            Value = value;
            Text  = value.ToString();
        }

        public override void OnApplyTemplate()
        {
            TextBox    = GetTemplateChild(PART_TextBox   ) as TextBox;
            UpButton   = GetTemplateChild(PART_UpButton  ) as RepeatButton;
            DownButton = GetTemplateChild(PART_DownButton) as RepeatButton;
        }
    }
}
