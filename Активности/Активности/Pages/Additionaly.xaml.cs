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
    /// Логика взаимодействия для Additionaly.xaml
    /// </summary>
    public partial class Additionaly : UserControl
    {
        public Additionaly()
        {
            InitializeComponent();
            set_init();
            counter();
        }

        private void scient_plus_Click(object sender, RoutedEventArgs e)
        {
            scient.Value++;
            counter();
        }

        private void scient_minus_Click(object sender, RoutedEventArgs e)
        {
            scient.Value--;
            counter();
        }

        private void Bear_plus_Click(object sender, RoutedEventArgs e)
        {
            Bear.Value++;
            counter();
        }

        private void Bear_minus_Click(object sender, RoutedEventArgs e)
        {
            Bear.Value--;
            counter();
        }

        private void Falmary_plus_Click(object sender, RoutedEventArgs e)
        {
            Falmary.Value++;
            counter();
        }

        private void Falmary_minus_Click(object sender, RoutedEventArgs e)
        {
            Falmary.Value--;
            counter();
        }

        private void Mushrooms_plus_Click(object sender, RoutedEventArgs e)
        {
            Mushrooms.Value++;
            counter();
        }

        private void Mushrooms_minus_Click(object sender, RoutedEventArgs e)
        {
            Mushrooms.Value--;
            counter();
        }

        private void Cruise_plus_Click(object sender, RoutedEventArgs e)
        {
            Cruise.Value++;
            counter();
        }

        private void Cruise_minus_Click(object sender, RoutedEventArgs e)
        {
            Cruise.Value--;
            counter();
        }

        private void Steps120_plus_Click(object sender, RoutedEventArgs e)
        {
            Steps120.Value++;
            counter();
        }

        private void Steps120_minus_Click(object sender, RoutedEventArgs e)
        {
            Steps120.Value--;
            counter();
        }

        private void CentralCity_plus_Click(object sender, RoutedEventArgs e)
        {
            CentralCity.Value++;
            counter();
        }

        private void CentralCity_minus_Click(object sender, RoutedEventArgs e)
        {
            CentralCity.Value--;
            counter();
        }

        private void BambooVillage_plus_Click(object sender, RoutedEventArgs e)
        {
            BambooVillage.Value++;
            counter();
        }

        private void BambooVillage_minus_Click(object sender, RoutedEventArgs e)
        {
            BambooVillage.Value--;
            counter();
        }

        private void Northerners_plus_Click(object sender, RoutedEventArgs e)
        {
            Northerners.Value++;
            counter();
        }

        private void Northerners_minus_Click(object sender, RoutedEventArgs e)
        {
            Northerners.Value--;
            counter();
        }

        private void Barbarians_plus_Click(object sender, RoutedEventArgs e)
        {
            Barbarians.Value++;
            counter();
        }

        private void Barbarians_minus_Click(object sender, RoutedEventArgs e)
        {
            Barbarians.Value--;
            counter();
        }

        private void counter()
        {
            Properties.Settings.Default.set_Barbarians = Barbarians.Value;
            Properties.Settings.Default.set_Northerners = Northerners.Value;
            Properties.Settings.Default.set_BambooVillage = BambooVillage.Value;
            Properties.Settings.Default.set_CentralCity = CentralCity.Value;
            Properties.Settings.Default.set_Steps120 = Steps120.Value;
            Properties.Settings.Default.set_Cruise = Cruise.Value;
            Properties.Settings.Default.set_Mushrooms = Mushrooms.Value;
            Properties.Settings.Default.set_Falmary = Falmary.Value;
            Properties.Settings.Default.set_Bear = Bear.Value;
            Properties.Settings.Default.set_scient = scient.Value;
            Properties.Settings.Default.Save();

            string Barbarians_count = Convert.ToString(Barbarians.Value) + " из " + Convert.ToString(Barbarians.Maximum);
            string Northerners_count = Convert.ToString(Northerners.Value) + " из " + Convert.ToString(Northerners.Maximum);
            string BambooVillage_count = Convert.ToString(BambooVillage.Value) + " из " + Convert.ToString(BambooVillage.Maximum);
            string CentralCity_count = Convert.ToString(CentralCity.Value) + " из " + Convert.ToString(CentralCity.Maximum);
            string Steps120_count = Convert.ToString(Steps120.Value) + " из " + Convert.ToString(Steps120.Maximum);
            string Cruise_count = Convert.ToString(Cruise.Value) + " из " + Convert.ToString(Cruise.Maximum);
            string Mushrooms_count = Convert.ToString(Mushrooms.Value) + " из " + Convert.ToString(Mushrooms.Maximum);
            string Falmary_count = Convert.ToString(Falmary.Value) + " из " + Convert.ToString(Falmary.Maximum);
            string Bear_count = Convert.ToString(Bear.Value) + " из " + Convert.ToString(Bear.Maximum);
            string scient_count = Convert.ToString(scient.Value) + " из " + Convert.ToString(scient.Maximum);
            Barbarians_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Barbarians_counter.Content = Barbarians_count;
            }));
            Northerners_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Northerners_counter.Content = Northerners_count;
            }));
            BambooVillage_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                BambooVillage_counter.Content = BambooVillage_count;
            }));
            CentralCity_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                CentralCity_counter.Content = CentralCity_count;
            }));
            Steps120_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Steps120_counter.Content = Steps120_count;
            }));
            Cruise_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Cruise_counter.Content = Cruise_count;
            }));
            Mushrooms_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Mushrooms_counter.Content = Mushrooms_count;
            }));
            Falmary_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Falmary_counter.Content = Falmary_count;
            }));
            Bear_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Bear_counter.Content = Bear_count;
            }));
            scient_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                scient_counter.Content = scient_count;
            }));
        }

        private void set_init()
        {
            Barbarians.Value = Properties.Settings.Default.set_Barbarians;
            Northerners.Value = Properties.Settings.Default.set_Northerners;
            BambooVillage.Value = Properties.Settings.Default.set_BambooVillage;
            CentralCity.Value = Properties.Settings.Default.set_CentralCity;
            Steps120.Value = Properties.Settings.Default.set_Steps120;
            Cruise.Value = Properties.Settings.Default.set_Cruise;
            Mushrooms.Value = Properties.Settings.Default.set_Mushrooms;
            Falmary.Value = Properties.Settings.Default.set_Falmary;
            Bear.Value = Properties.Settings.Default.set_Bear;
            scient.Value = Properties.Settings.Default.set_scient;
            Properties.Settings.Default.Save();
        }
    }
}
