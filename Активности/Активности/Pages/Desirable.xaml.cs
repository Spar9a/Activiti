﻿using System;
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
            // counter();
        }
        private void Steps25_plus_Click(object sender, RoutedEventArgs e)
        {
            Steps25.Value++;
            // counter();
        }

        private void Steps25_minus_Click(object sender, RoutedEventArgs e)
        {
            Steps25.Value--;
            //   counter();
        }
        private void Brakteat5Quest_plus_Click(object sender, RoutedEventArgs e)
        {
            Brakteat5Quest.Value++;
            //  counter();
        }

        private void Brakteat5Quest_minus_Click(object sender, RoutedEventArgs e)
        {
            Brakteat5Quest.Value--;
            // counter();
        }
        private void Jumps_plus_Click(object sender, RoutedEventArgs e)
        {
            Jumps.Value++;
            //  counter();
        }

        private void Jumps_minus_Click(object sender, RoutedEventArgs e)
        {
            Jumps.Value--;
            // counter();
        }

        /*private void counter()
        {
            string guild_10_count = Convert.ToString(guild_10.Value) + " из " + Convert.ToString(guild_10.Maximum);
            string guild_build_count = Convert.ToString(guild_build.Value) + " из " + Convert.ToString(guild_build.Maximum);
            string pirate_island_count = Convert.ToString(pirate_island.Value) + " из " + Convert.ToString(pirate_island.Maximum);
            guild_10_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_10_counter.Content = guild_10_count;
                if (guild_10.Value == guild_10.Maximum)
                    guild_10_label.Background = guild_10_label_Green.Background;
                else
                    guild_10_label.Background = guild_10_label_Red.Background;
            }));
            guild_build_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                guild_build_counter.Content = guild_build_count;
                if (guild_build.Value == guild_build.Maximum)
                    guild_10_label1.Background = guild_10_label_Green.Background;
                else
                    guild_10_label1.Background = guild_10_label_Red.Background;
            }));
            pirate_island_counter.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                pirate_island_counter.Content = pirate_island_count;
                if (pirate_island.Value == pirate_island.Maximum)
                    pirate_islandlabel.Background = guild_10_label_Green.Background;
                else
                    pirate_islandlabel.Background = guild_10_label_Red.Background;
            }));
        }*/
    }
}
