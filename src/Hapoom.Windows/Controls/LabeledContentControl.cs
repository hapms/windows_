using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hapoom.Windows.Controls
{
    public class LabeledContentControl : ContentControl
    {
        public static readonly DependencyProperty LabelProperty
            = DependencyProperty.Register("Label",
                                           typeof(string), 
                                           typeof(LabeledContentControl),
                                           new PropertyMetadata(null, OnLabelPropertyChangedCallback));
        
        public static string GetLabelProperty(DependencyObject d)
        {
            return (string)d.GetValue(LabelProperty);
        }
        public static void SetLabelProperty(DependencyObject d, string value)
        {
            d.SetValue(LabelProperty, value);
        }
        private static void OnLabelPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = (LabeledContentControl)d;
            c.OnLabelChanged((string)e.NewValue);
        }

        public string Label
        {
            get { return GetLabelProperty(this); }
            set { SetLabelProperty(this, value); }
        }

        protected void OnLabelChanged(string value)
        {
            Label = value;
        }
    }
}
