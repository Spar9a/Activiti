using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Activity
{
    class ControlButton : Button
    {
        public static readonly DependencyProperty TabNameProperty = DependencyProperty.Register("TabName", typeof(string), typeof(ControlButton));
        public string TabName
        {
            get { return GetValue(TabNameProperty).ToString(); }
            set { SetValue(TabNameProperty, value); }
        }
        public MainWindow.QuestTabs questTab;
    }
}
