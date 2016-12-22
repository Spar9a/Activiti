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
    /// Логика взаимодействия для Desirable.xaml
    /// </summary>
    public partial class Desirable : UserControl
    {
        public Desirable()
        {
            InitializeComponent();
            counter();
        }
        private void Steps25_plus_Click(object sender, RoutedEventArgs e)
        {
            Steps25.Value++;
            counter();
        }

        private void Steps25_minus_Click(object sender, RoutedEventArgs e)
        {
            Steps25.Value--;
            counter();
        }
        private void Brakteat5Quest_plus_Click(object sender, RoutedEventArgs e)
        {
            Brakteat5Quest.Value++;
            counter();
        }

        private void Brakteat5Quest_minus_Click(object sender, RoutedEventArgs e)
        {
            Brakteat5Quest.Value--;
            counter();
        }
        private void Jumps_plus_Click(object sender, RoutedEventArgs e)
        {
            Jumps.Value++;
            counter();
        }

        private void Jumps_minus_Click(object sender, RoutedEventArgs e)
        {
            Jumps.Value--;
            counter();
        }

        private void counter()
        {
            string Steps25_count = Convert.ToString(Steps25.Value) + " из " + Convert.ToString(Steps25.Maximum);
            string Brakteat5Quest_count = Convert.ToString(Brakteat5Quest.Value) + " из " + Convert.ToString(Brakteat5Quest.Maximum);
            string Jumps_count = Convert.ToString(Jumps.Value) + " из " + Convert.ToString(Jumps.Maximum);
            Steps25_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Steps25_counter.Content = Steps25_count;
            }));
            Brakteat5Quest_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Brakteat5Quest_counter.Content = Brakteat5Quest_count;
            }));
            Jumps_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Jumps_counter.Content = Jumps_count;
            }));
        }
    }
}
