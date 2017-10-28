using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Hapoom.Windows.Controls
{
    [TemplatePart(Name = PART_Ant1, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_Ant2, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_Ant3, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_Ant4, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_Ant5, Type = typeof(Rectangle))]
    public class BusyIndicator : Control
    {
        public const string PART_Ant1 = "PART_Ant1";
        public const string PART_Ant2 = "PART_Ant2";
        public const string PART_Ant3 = "PART_Ant3";
        public const string PART_Ant4 = "PART_Ant4";
        public const string PART_Ant5 = "PART_Ant5";

        Rectangle  _ant1;
        Rectangle  _ant2; 
        Rectangle  _ant3;
        Rectangle  _ant4;
        Rectangle  _ant5;
        KeyTime    _keyTime1;
        KeyTime    _keyTime2; 
        KeyTime    _keyTime3;
        KeyTime    _keyTime4;
        KeyTime    _keyTime5;
        double     _x1;
        double     _x2; 
        double     _x3;
        double     _x4;
        double     _x5;
        bool       _isStoryboardRunning;
        Storyboard _storyboard1;
        Storyboard _storyboard2;
        Storyboard _storyboard3;
        Storyboard _storyboard4;
        Storyboard _storyboard5;

        public BusyIndicator()
        {
            Loaded += OnLoaded;
        }

        #region IsBusyProperty
        public static readonly DependencyProperty IsBusyProperty
            = DependencyProperty.Register("IsBusy",
                                           typeof(bool), 
                                           typeof(BusyIndicator),
                                           new PropertyMetadata(false, OnIsBusyPropertyChanged));
        
        public static bool GetIsBusy(DependencyObject d)
        {
            return (bool)d.GetValue(IsBusyProperty);
        }
        public static void SetIsBusy(DependencyObject d, bool value)
        {
            d.SetValue(IsBusyProperty, value);
        }

        private static void OnIsBusyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bi = (BusyIndicator)d;
            bi.OnIsBusyChanged((bool)e.NewValue);
        }
        #endregion

        public bool IsBusy
        {
            get { return GetIsBusy(this); }
            set { SetIsBusy(this, value); }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (IsBusy)
                StartAnimation();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (_isStoryboardRunning)
            {
                StopAnimation();
                StartAnimation();
            }
        }

        public override void OnApplyTemplate()
        {
            _ant1 = (Rectangle)GetTemplateChild("PART_Ant1");
            _ant2 = (Rectangle)GetTemplateChild("PART_Ant2");
            _ant3 = (Rectangle)GetTemplateChild("PART_Ant3");
            _ant4 = (Rectangle)GetTemplateChild("PART_Ant4");
            _ant5 = (Rectangle)GetTemplateChild("PART_Ant5");

            SetTransformGroup(_ant1);
            SetTransformGroup(_ant2);
            SetTransformGroup(_ant3);
            SetTransformGroup(_ant4);
            SetTransformGroup(_ant5);
        }

        protected virtual void OnIsBusyChanged(bool isBusy)
        {
            if (isBusy)
                StartAnimation();
            else
                StopAnimation();
        }

        private void SetTransformGroup(Rectangle ant)
        {
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(new TranslateTransform() { X = -5 });
            ant.RenderTransform = transformGroup;
        }

        private void StartAnimation()
        {
            if (_isStoryboardRunning)
                return;
            if (_ant1 == null)
                return;

            UpdateFigures();

            _storyboard1 = GetStoryboard(TimeSpan.FromMilliseconds(000));
            _storyboard2 = GetStoryboard(TimeSpan.FromMilliseconds(200));
            _storyboard3 = GetStoryboard(TimeSpan.FromMilliseconds(400));
            _storyboard4 = GetStoryboard(TimeSpan.FromMilliseconds(600));
            _storyboard5 = GetStoryboard(TimeSpan.FromMilliseconds(800));
            
            _ant1.Visibility = Visibility.Visible;
            _ant2.Visibility = Visibility.Visible;
            _ant3.Visibility = Visibility.Visible;
            _ant4.Visibility = Visibility.Visible;
            _ant5.Visibility = Visibility.Visible;

            _storyboard1.Begin(_ant1, true);
            _storyboard2.Begin(_ant2, true);
            _storyboard3.Begin(_ant3, true);
            _storyboard4.Begin(_ant4, true);
            _storyboard5.Begin(_ant5, true);

            _isStoryboardRunning = true;
        }

        private void StopAnimation()
        {
            if (!_isStoryboardRunning)
                return;

            _ant1.Visibility = Visibility.Hidden;
            _ant2.Visibility = Visibility.Hidden;
            _ant3.Visibility = Visibility.Hidden;
            _ant4.Visibility = Visibility.Hidden;
            _ant5.Visibility = Visibility.Hidden;

            _storyboard1.Stop(_ant1);
            _storyboard2.Stop(_ant2);
            _storyboard3.Stop(_ant3);
            _storyboard4.Stop(_ant4);
            _storyboard5.Stop(_ant5);

            _isStoryboardRunning = false;
        }

        private void UpdateFigures()
        {
            _x1 = ActualWidth * 0.000;
            _x2 = ActualWidth * 0.375;
            _x3 = ActualWidth * 0.625;
            _x4 = ActualWidth * 1.000;
            _x5 = ActualWidth * 1.000;

            _keyTime1 = TimeSpan.FromMilliseconds(0000);
            _keyTime2 = TimeSpan.FromMilliseconds(0500);
            _keyTime3 = TimeSpan.FromMilliseconds(2000);
            _keyTime4 = TimeSpan.FromMilliseconds(2500);
            _keyTime5 = TimeSpan.FromMilliseconds(3500);
        }

        private Storyboard GetStoryboard(TimeSpan beginTime)
        {
            var storyboard = new Storyboard {
                BeginTime      = beginTime,
                RepeatBehavior = RepeatBehavior.Forever
            };
            storyboard.Children.Add(GetAnimation());
            Storyboard.SetTargetProperty(storyboard, new PropertyPath("(Rectangle.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
            return storyboard;
        }

        private DoubleAnimationUsingKeyFrames GetAnimation()
        {
            var animation = new DoubleAnimationUsingKeyFrames();
            animation.KeyFrames.Add(GetKeyFrame(_keyTime1             , _x1));
            animation.KeyFrames.Add(GetKeyFrameWithPowerEase(_keyTime2, _x2));
            animation.KeyFrames.Add(GetKeyFrame(_keyTime3             , _x3));
            animation.KeyFrames.Add(GetKeyFrameWithPowerEase(_keyTime4, _x4));
            animation.KeyFrames.Add(GetKeyFrame(_keyTime5             , _x5));
            return animation;
        }

        private EasingDoubleKeyFrame GetKeyFrame(KeyTime keytime, double value)
        {
            var result = new EasingDoubleKeyFrame() {
                KeyTime        = keytime,
                Value          = value,
            };
            return result;
        }

        private EasingDoubleKeyFrame GetKeyFrameWithPowerEase(KeyTime keytime, double value)
        {
            var result = new EasingDoubleKeyFrame() {
                KeyTime        = keytime,
                Value          = value,
                EasingFunction = new PowerEase {
                                     Power = 1.3,
                                     EasingMode = EasingMode.EaseInOut
                                 }
            };
            return result;
        }
    }
}
