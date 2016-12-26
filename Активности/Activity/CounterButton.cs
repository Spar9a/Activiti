using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Activity
{
    class CounterButton : Button
    {
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(CounterButton));
        public ImageSource Image
        {
            get { return GetValue(ImageProperty) as ImageSource; }
            set { SetValue(ImageProperty, value); }
        }
    }
}
