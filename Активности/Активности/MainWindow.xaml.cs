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

namespace Активности
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void frame_Copy1_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void frame_Copy3_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void frame_Copy2_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void guil_10_x1_Click(object sender, RoutedEventArgs e)
        {
                guild_10.Value++;
        }

        private void guil_10_x10_Click(object sender, RoutedEventArgs e)
        {
            double i;
            i = 10.0 - guild_10.Value;
            guild_10.Value += i;
        }

        private void guil_build_x1_Click(object sender, RoutedEventArgs e)
        {
            guild_build.Value++;
        }
        private void guil_build_x4_Click(object sender, RoutedEventArgs e)
        {
            double i;
            i = 4.0 - guild_build.Value;
            guild_build.Value += i;
        }
        private void pirate_island_x1_Click(object sender, RoutedEventArgs e)
        {
            pirate_island.Value++;
        }
        private void pirate_island_x2_Click(object sender, RoutedEventArgs e)
        {
            double i;
            i = 2.0 - pirate_island.Value;
            pirate_island.Value += i;
        }
        private void pack_x1_Click(object sender, RoutedEventArgs e)
        {
            pack.Value++;
        }
        private void guild_dog_x1_Click(object sender, RoutedEventArgs e)
        {
            guild_dog.Value++;
        }
    }
}
