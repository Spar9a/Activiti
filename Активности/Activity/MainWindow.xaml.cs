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
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Activity.Pages;
using System.Diagnostics;

namespace Activity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        private DateTime moscowDateTime;
        protected Process[] procs;
        public MainWindow()
        {
            InitializeComponent();
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipTitle = "Программа помещена в трей";
            m_notifyIcon.BalloonTipText = "Чтобы открыть программу снова, нажмите на её иконку";
            m_notifyIcon.Text = "Activiti"; //Пишется когда наводишь мышкой на программу в трее
            using (Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Activity;component/image/murr.ico")).Stream)
            {
                m_notifyIcon.Icon = new System.Drawing.Icon(iconStream);
                m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
            }
            Update(null, null);
            ContentBlock.Content = new Necessary();
            Timer Timer1 = new Timer();
            Timer1.Interval = 1000;
            Timer1.Tick += new EventHandler(Update);
            Timer1.Tick += new EventHandler(RevaSearch);
            Timer1.Enabled = true;
        }
        void RevaSearch(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Process[] procs = Process.GetProcesses();
                foreach (Process p in procs)
                    if (p.ProcessName == "notepad")
                    {
                        Show();
                        WindowState = m_storedWindowState;
                    }
            }
        }
        void Update(object sender, EventArgs e)
        {
            moscowDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, moscowTimeZone);

            Server_Time.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Server_Time.Content = moscowDateTime.ToShortTimeString();
            }));

            if (Properties.Settings.Default.last_used_day.DayOfYear != moscowDateTime.DayOfYear)
            {
                ResetQuests();

                if (moscowDateTime.DayOfWeek == DayOfWeek.Monday) ResetWeekQuests();
            }

        }

        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);

            }
            else
                m_storedWindowState = WindowState;
        }

        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }

        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }

        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
            Properties.Settings.Default.Save();
        }

        private void ContentControl_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            string name = btn.Name;
            switch (name)
            {
                case "necessarily":
                    ContentBlock.Content = new Necessary();
                    break;
                case "additional":
                    ContentBlock.Content = new Additionaly();
                    break;
                case "desirable":
                    ContentBlock.Content = new Desirable();
                    break;
                case "minimum":
                    ContentBlock.Content = new Minimum();
                    break;
            }
        }

        public void ResetQuests()
        {
            Properties.Settings.Default.set_nec_guild10 = 0;
            Properties.Settings.Default.set_nec_guild_build = 0;
            Properties.Settings.Default.set_nec_ostrov = 0;
            Properties.Settings.Default.set_nec_pack = 0;
            Properties.Settings.Default.set_min_Arena4Gods = 0;
            Properties.Settings.Default.set_min_Bath = 0;
            Properties.Settings.Default.set_min_BlackMarket = 0;
            Properties.Settings.Default.set_min_KeepersDay = 0;
            Properties.Settings.Default.set_des_Jumps = 0;
            Properties.Settings.Default.set_Barbarians = 0;
            Properties.Settings.Default.set_Northerners = 0;
            Properties.Settings.Default.set_BambooVillage = 0;
            Properties.Settings.Default.set_CentralCity = 0;
            Properties.Settings.Default.set_Cruise = 0;
            Properties.Settings.Default.set_Mushrooms = 0;
            Properties.Settings.Default.set_Falmary = 0;
            Properties.Settings.Default.set_Bear = 0;
            Properties.Settings.Default.set_scient = 0;
            Properties.Settings.Default.last_used_day = moscowDateTime;
            Properties.Settings.Default.Save();
            System.Windows.MessageBox.Show("Все ежедневные квесты обновились!");
        }
        public void ResetWeekQuests()
        {
            Properties.Settings.Default.set_min_KeepersWeek = 0;
            Properties.Settings.Default.set_des_Steps25 = 0;
            Properties.Settings.Default.set_des_Brakteat5Quest = 0;
            Properties.Settings.Default.set_Steps120 = 0;
            Properties.Settings.Default.Save();
            System.Windows.MessageBox.Show("Все еженедельные квесты обновились!");
        }
    }
}
