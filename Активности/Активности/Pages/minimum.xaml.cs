using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Активности.Pages
{
    /// <summary>
    /// Логика взаимодействия для minimum.xaml
    /// </summary>
    public partial class minimum : UserControl
    {
        public static object ContentBlock { get; private set; }

        public minimum()
        {
            InitializeComponent();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            string name = btn.Name;
            switch (name)
            {
                case "page_1":
                    ContentControlMinimum.Content = new minimum();
                  //  ActivePage1.Visibility Property = false;
                    break;
                case "page_2":
                    ContentControlMinimum.Content = new page2Minimum();
                    break;
                case "page_3":
                    ContentControlMinimum.Content = new page3Minimum();
                    break;
                case "page_4":
                    ContentControlMinimum.Content = new page4Minimum();
                    break;
            }
        }
    }
}
