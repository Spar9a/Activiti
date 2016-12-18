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
    /// Логика взаимодействия для page2Minimum.xaml
    /// </summary>
    public partial class page2Minimum : UserControl
    {
        public page2Minimum()
        {
            InitializeComponent();
            guild_counter();
            build_counter();
            pirate_counter();
        }
        private void guild_x10_pluse_Click(object sender, RoutedEventArgs e)
        {
            guild_10.Value++;
            guild_counter();
        }

        private void guild_x10_minuse_Click(object sender, RoutedEventArgs e)
        {
            guild_10.Value--;
            guild_counter();
        }
        private void guild_build_pluse_Click(object sender, RoutedEventArgs e)
        {
            guild_build.Value++;
            build_counter();
        }

        private void guild_build_minuse_Click(object sender, RoutedEventArgs e)
        {
            guild_build.Value--;
            build_counter();
        }
        private void pirate_island_pluse_Click(object sender, RoutedEventArgs e)
        {
            pirate_island.Value++;
            pirate_counter();
        }

        private void pirate_island_minuse_Click(object sender, RoutedEventArgs e)
        {
            pirate_island.Value--;
            pirate_counter();
        }
        private void guild_counter()
        {
            string guild_10_count = Convert.ToString(guild_10.Value) + " из " + Convert.ToString(guild_10.Maximum);
            guild_10_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_10_counter.Content = guild_10_count;
            }));
        }

        private void build_counter()
        {
            string guild_build_count = Convert.ToString(guild_build.Value) + " из " + Convert.ToString(guild_build.Maximum);
            guild_build_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_build_counter.Content = guild_build_count;
            }));
        }

        private void pirate_counter()
        {
            string pirate_island_count = Convert.ToString(pirate_island.Value) + " из " + Convert.ToString(pirate_island.Maximum);
            pirate_island_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                pirate_island_counter.Content = pirate_island_count;
            }));
        }
    }
}
