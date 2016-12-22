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
    /// Логика взаимодействия для Minimum.xaml
    /// </summary>
    public partial class Minimum : UserControl
    {
        public Minimum()
        {
            InitializeComponent();
            counter();
        }
        private void KeepersDay_plus_Click(object sender, RoutedEventArgs e)
        {
            KeepersDay.Value++;
            counter();
        }

        private void KeepersDay_minus_Click(object sender, RoutedEventArgs e)
        {
            KeepersDay.Value--;
            counter();
        }
        private void KeepersWeek_plus_Click(object sender, RoutedEventArgs e)
        {
            KeepersWeek.Value++;
            counter();
        }

        private void KeepersWeek_minus_Click(object sender, RoutedEventArgs e)
        {
            KeepersWeek.Value--;
            counter();
        }
        private void Arena4Gods_plus_Click(object sender, RoutedEventArgs e)
        {
            Arena4Gods.Value++;
            counter();
        }

        private void Arena4Gods_minus_Click(object sender, RoutedEventArgs e)
        {
            Arena4Gods.Value--;
            counter();
        }

        private void Bath_plus_Click(object sender, RoutedEventArgs e)
        {
            Bath.Value++;
            counter();
        }

        private void Bath_minus_Click(object sender, RoutedEventArgs e)
        {
            Bath.Value--;
            counter();
        }

        private void BlackMarket_plus_Click(object sender, RoutedEventArgs e)
        {
            BlackMarket.Value++;
            counter();
        }

        private void BlackMarket_minus_Click(object sender, RoutedEventArgs e)
        {
            BlackMarket.Value--;
            counter();
        }
        private void counter()
        {
            string Arena4Gods_count = Convert.ToString(Arena4Gods.Value) + " из " + Convert.ToString(Arena4Gods.Maximum);
            string Bath_count = Convert.ToString(Bath.Value) + " из " + Convert.ToString(Bath.Maximum);
            string BlackMarket_count = Convert.ToString(BlackMarket.Value) + " из " + Convert.ToString(BlackMarket.Maximum);
            string KeepersWeek_count = Convert.ToString(KeepersWeek.Value) + " из " + Convert.ToString(KeepersWeek.Maximum);
            string KeepersDay_count = Convert.ToString(KeepersDay.Value) + " из " + Convert.ToString(KeepersDay.Maximum);
            KeepersWeek_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                KeepersWeek_counter.Content = KeepersWeek_count;
            }));
            Arena4Gods_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Arena4Gods_counter.Content = Arena4Gods_count;
            }));
            Bath_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Bath_counter.Content = Bath_count;
            }));
            BlackMarket_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                BlackMarket_counter.Content = BlackMarket_count;
            }));
            KeepersDay_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                KeepersDay_counter.Content = KeepersDay_count;
            }));
        }
    }
}
