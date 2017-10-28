using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Hapoom.Windows
{
    public class WindowBase : Window
    {
        public WindowBase()
        {
            SetCommandBindings();
            StateChanged += OnStateChanged;
            SizeChanged  += OnSizeChanged;
            ThemeSelector.Instance.Apply(this);
        }

        #region DropShadowColor
        public static readonly DependencyProperty DropShadowColorProperty
            = DependencyProperty.Register("DropShadowColor",
                                           typeof(Color), 
                                           typeof(WindowBase),
                                           new PropertyMetadata(Colors.Red, null));
        public static Color GetDropShadowColor(DependencyObject d)
        {
            return (Color)d.GetValue(DropShadowColorProperty);
        }
        public static void SetDropShadowColor(DependencyObject d, Color value)
        {
            d.SetValue(DropShadowColorProperty, value);
        }
        public Color DropShadowColor
        {
            get { return GetDropShadowColor(this); }
            set { SetDropShadowColor(this, value); }
        }
        #endregion

        #region Logo
        public static readonly DependencyProperty LogoProperty
            = DependencyProperty.Register("Logo",
                                           typeof(object), 
                                           typeof(WindowBase),
                                           new PropertyMetadata(null, OnLogoPropertyChangedCallback));
        private static void OnLogoPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(LogoProperty, e.NewValue);
        }
        public static object GetLogo(DependencyObject d)
        {
            return d.GetValue(Title2Property);
        }
        public static void SetLogo(DependencyObject d, object value)
        {
            d.SetValue(Title2Property, value);
        }
        public object Logo
        {
            get { return GetLogo(this); }
            set { SetLogo(this, value); }
        }
        #endregion

        #region Title2
        public static readonly DependencyProperty Title2Property
            = DependencyProperty.Register("Title2",
                                           typeof(object), 
                                           typeof(WindowBase),
                                           new PropertyMetadata(null, null));
        public static object GetTitle2(DependencyObject d)
        {
            return d.GetValue(Title2Property);
        }
        public static void SetTitle2(DependencyObject d, object value)
        {
            d.SetValue(Title2Property, value);
        }
        public object Title2
        {
            get { return GetTitle2(this); }
            set { SetTitle2(this, value); }
        }
        #endregion

        #region Snap

        public static readonly DependencyProperty SnapStateProperty
            = DependencyProperty.Register("SnapState",
                                           typeof(WindowSnapState), 
                                           typeof(WindowBase),
                                           new PropertyMetadata(WindowSnapState.Not, null));
        public static WindowSnapState GetSnapState(DependencyObject d)
        {
            return (WindowSnapState)d.GetValue(SnapStateProperty);
        }
        public static void SetSnapState(DependencyObject d, WindowSnapState value)
        {
            d.SetValue(SnapStateProperty, value);
        }
        public WindowSnapState SnapState
        {
            get { return GetSnapState(this); }
            set { SetSnapState(this, value); }
        }

        #endregion

        private void SetCommandBindings()
        {
            CommandBindings.AddRange(new[] {
                new CommandBinding(SystemCommands.MinimizeWindowCommand, (sender, e) => { SystemCommands.MinimizeWindow(this); }),
                new CommandBinding(SystemCommands.MaximizeWindowCommand, (sender, e) => { SystemCommands.MaximizeWindow(this); }),
                new CommandBinding(SystemCommands.RestoreWindowCommand , (sender, e) => { SystemCommands.RestoreWindow (this); }),
                new CommandBinding(SystemCommands.CloseWindowCommand   , (sender, e) => { SystemCommands.CloseWindow   (this); }),
            });
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            MaxHeight = (WindowState == WindowState.Maximized)
                            ? Screen.GetScreen(this).WorkingArea.Height 
                                + BorderThickness.Top 
                                + BorderThickness.Bottom 
                                + Padding.Top
                                + Padding.Bottom
                            : double.PositiveInfinity;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SnapState = SnapStateOf(this);
        }

        private void OnLogoMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Close();
            }
        }

        private static WindowSnapState SnapStateOf(WindowBase window)
        {
            var screen = Screen.GetScreen(window);
            if (screen == null)
                throw new Exception();
            if (window.ActualHeight != screen.WorkingArea.Height)
                return WindowSnapState.Not;

            var l = window.Left == screen.WorkingArea.Left;
            var r = window.Left + window.ActualWidth == screen.WorkingArea.Right;
            if (l && r)
                return WindowSnapState.LeftRight;
            if (l)
                return WindowSnapState.Left;
            if (r)
                return WindowSnapState.Right;
            return WindowSnapState.Middle;
        }
    }
}
