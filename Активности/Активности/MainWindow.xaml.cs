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
using Активности.Pages;
using System.Diagnostics;

namespace Активности
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private DateTime moscowDateTime;
        protected Process[] procs;
        public MainWindow()
        {
            TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            moscowDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, moscowTimeZone);
            InitializeComponent();
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipTitle = "Программа помещена в трей";
            m_notifyIcon.BalloonTipText = "Чтобы открыть программу снова, нажмите на её иконку";
            m_notifyIcon.Text = "Activiti"; //Пишется когда наводишь мышкой на программу в трее
            using (Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Активности;component/image/murr.ico")).Stream)
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
            Server_Time.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Server_Time.Content = moscowDateTime.TimeOfDay.ToString();
            }));

            if (Properties.Settings.Default.last_used_day.DayOfYear != moscowDateTime.DayOfYear) ResetQuests();
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
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.last_used_day = moscowDateTime;
            Properties.Settings.Default.Save();
            System.Windows.MessageBox.Show("Все ежедневные квесты обновились!");
        }
    }
}
