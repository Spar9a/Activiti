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

namespace Activity.Pages
{
    /// <summary>
    /// Логика взаимодействия для Desirable.xaml
    /// </summary>
    public partial class Desirable : UserControl
    {
        public Desirable()
        {
            InitializeComponent();
            var quests = App.dict["Quests"] as Quest[];
            foreach (Quest q in quests)
            {
                if (q.questCategory == MainWindow.QuestTabs.Desirable) questList.Children.Add(q);
            }
            set_init();
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
            Properties.Settings.Default.set_des_Steps25 = Steps25.Value;
            Properties.Settings.Default.set_des_Brakteat5Quest = Brakteat5Quest.Value;
            Properties.Settings.Default.set_des_Jumps = Jumps.Value;
            Properties.Settings.Default.Save();

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

        private void set_init()
        {
            Steps25.Value = Properties.Settings.Default.set_des_Steps25;
            Brakteat5Quest.Value = Properties.Settings.Default.set_des_Brakteat5Quest;
            Jumps.Value = Properties.Settings.Default.set_des_Jumps;
            Properties.Settings.Default.Save();
        }
    }
}
