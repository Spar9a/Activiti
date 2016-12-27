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
    public partial class MainWindow : Window
    {
        public enum QuestTabs // отсюда он генерит вкладочки, просто добавляем или убираем и в проге появляются а так же маштабируются вкладочки
        {
            Обязательно,
            Минимум,
            Желательно,
            Дополнительно,
            Данжи
        };

        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private TimeZoneInfo moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        private DateTime moscowDateTime;
        private Dictionary<QuestTabs, Pages.TabPage> pagesCache = new Dictionary<QuestTabs, Pages.TabPage>();
        protected Process[] procs;
        public MainWindow()
        {
            InitializeComponent();
            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipTitle = "Программа помещена в трей";
            m_notifyIcon.BalloonTipText = "Чтобы открыть программу снова, нажмите на её иконку";
            m_notifyIcon.Text = "Activity"; //Пишется когда наводишь мышкой на программу в трее
            using (Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Activity;component/image/murr.ico")).Stream)
            {
                m_notifyIcon.Icon = new System.Drawing.Icon(iconStream);
                m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
            }
            Update(null, null);
            LoadPage(QuestTabs.Обязательно);
            Timer Timer1 = new Timer();
            Timer1.Interval = 5000;
            Timer1.Tick += new EventHandler(Update);
            Timer1.Tick += new EventHandler(RevaSearch);
            Timer1.Enabled = true;

            int tabCount = Enum.GetValues(typeof(QuestTabs)).Length;
            foreach (QuestTabs Tab in Enum.GetValues(typeof(QuestTabs)))
            {
                ControlButton cb = new ControlButton();
                cb.Width = TabControler.Width / tabCount + 1;
                cb.questTab = Tab;
                cb.TabName = Tab.ToString();
                cb.Click += ContentControl_Click;
                TabControler.Children.Add(cb);
            }
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

                if (Properties.Settings.Default.last_used_day.DayOfWeek > moscowDateTime.DayOfWeek || (moscowDateTime - Properties.Settings.Default.last_used_day).TotalDays >= 7) ResetWeekQuests();
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

        private void SaveData()
        {
            if (Properties.Settings.Default.questSaves == null) Properties.Settings.Default.questSaves = new System.Collections.ArrayList();
            Properties.Settings.Default.questSaves.Clear();
            var quests = App.dict["Quests"] as Quest[];
            Properties.Settings.Default.questSaves.AddRange(quests.Select(x => x.questCounter).ToArray());
            Properties.Settings.Default.last_used_day = moscowDateTime;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
            SaveData();
        }

        public void LoadPage(QuestTabs tab)
        {
            Pages.TabPage page;
            if (!pagesCache.TryGetValue(tab, out page))
            {
                page = new Pages.TabPage();
                var quests = App.dict["Quests"] as Quest[];
                foreach (Quest q in quests)
                {
                    if (q.questCategory == tab) page.questList.Children.Add(q);
                }
                pagesCache.Add(tab, page);
            }
            ContentBlock.Content = page;
        }

        private void ContentControl_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as ControlButton;
            LoadPage(btn.questTab);
        }

        public void ResetQuests()
        {
            var quests = App.dict["Quests"] as Quest[];
            foreach (Quest q in quests)
            {
                if (q.questType != Quest.QuestType.Weekly) q.questCounter = 0;
            }
            SaveData();
            System.Windows.MessageBox.Show("Все ежедневные квесты обновились!");
        }

        public void ResetWeekQuests()
        {
            var quests = App.dict["Quests"] as Quest[];
            foreach (Quest q in quests)
            {
                if (q.questType == Quest.QuestType.Weekly) q.questCounter = 0;
            }
            SaveData();
            System.Windows.MessageBox.Show("Все еженедельные квесты обновились!");
        }
    }
}
