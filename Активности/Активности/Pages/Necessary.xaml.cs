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
    /// Логика взаимодействия для Necessary.xaml
    /// </summary>
    public partial class Necessary : UserControl
    {
        public Necessary()
        {
            InitializeComponent();
            set_init();
            counter();
        }

        private void guild_10_plus_Click(object sender, RoutedEventArgs e)
        {
            guild_10.Value++;
            counter();
        }

        private void guild_10_minus_Click(object sender, RoutedEventArgs e)
        {
            guild_10.Value--;
            counter();
        }

        private void guild_build_plus_Click(object sender, RoutedEventArgs e)
        {
            guild_build.Value++;
            counter();
        }

        private void guild_build_minus_Click(object sender, RoutedEventArgs e)
        {
            guild_build.Value--;
            counter();
        }

        private void pirate_island_plus_Click(object sender, RoutedEventArgs e)
        {
            pirate_island.Value++;
            counter();
        }

        private void pirate_island_minus_Click(object sender, RoutedEventArgs e)
        {
            pirate_island.Value--;
            counter();
        }

        private void pack_plus_Click(object sender, RoutedEventArgs e)
        {
            pack.Value++;
            counter();
        }

        private void pack_minus_Click(object sender, RoutedEventArgs e)
        {
            pack.Value--;
            counter();
        }

        private void counter()
        {
            Properties.Settings.Default.set_nec_guild10 = guild_10.Value;
            Properties.Settings.Default.set_nec_guild_build = guild_build.Value;
            Properties.Settings.Default.set_nec_ostrov = pirate_island.Value;
            Properties.Settings.Default.set_nec_pack = pack.Value;
            Properties.Settings.Default.Save();

            string guild_10_count = Convert.ToString(guild_10.Value) + " из " + Convert.ToString(guild_10.Maximum);
            string guild_build_count = Convert.ToString(guild_build.Value) + " из " + Convert.ToString(guild_build.Maximum);
            string pirate_island_count = Convert.ToString(pirate_island.Value) + " из " + Convert.ToString(pirate_island.Maximum);
            string pack_count = Convert.ToString(pack.Value) + " из " + Convert.ToString(pack.Maximum);
            guild_10_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_10_counter.Content = guild_10_count;
                /*if (guild_10.Value == guild_10.Maximum)
                    guild_10_label.Background = guild_10_label_Green.Background;
                else
                    guild_10_label.Background = guild_10_label_Red.Background;*/
            }));
            guild_build_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_build_counter.Content = guild_build_count;
               /* if (guild_build.Value == guild_build.Maximum)
                    guild_10_label1.Background = guild_10_label_Green.Background;
                else
                    guild_10_label1.Background = guild_10_label_Red.Background;*/
            }));
            pirate_island_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                pirate_island_counter.Content = pirate_island_count;
               /* if (pirate_island.Value == pirate_island.Maximum)
                    pirate_islandlabel.Background = guild_10_label_Green.Background;
                else
                    pirate_islandlabel.Background = guild_10_label_Red.Background;*/
            }));
            pack_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                pack_counter.Content = pack_count;
            }));
        }

        private void set_init()
        {
            guild_10.Value = Properties.Settings.Default.set_nec_guild10;
            guild_build.Value = Properties.Settings.Default.set_nec_guild_build;
            pirate_island.Value = Properties.Settings.Default.set_nec_ostrov;
            pack.Value = Properties.Settings.Default.set_nec_pack;
            Properties.Settings.Default.Save();
        }
    }
}
