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

namespace Activity
{
    /// <summary>
    /// Логика взаимодействия для PageButton.xaml
    /// </summary>
    public partial class PageButton : UserControl
    {
        public PageButton()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ContentPageButtonProperty = DependencyProperty.Register("ContentPageButton", typeof(string), typeof(PageButton));
        public string ContentPageButton
        {
            get { return textPage.Content.ToString(); }
            set { textPage.Content = value; }
        }
    }
}
