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

namespace Activity
{
    public partial class Quest : UserControl
    {
        public static int questId = 0;
        private MainWindow.QuestTabs _questCategory;
        public MainWindow.QuestTabs questCategory { get { return _questCategory; } set { _questCategory = value; } }
        public string questName
        {
            get { return labelQuestName.Content.ToString(); }
            set { labelQuestName.Content = value; }
        }
        private QuestType _questType;
        public QuestType questType
        {
            get { return _questType; }
            set
            {
                _questType = value;
                switch (value)
                {
                    case QuestType.Daily:
                        typeImage.Source = new BitmapImage(new Uri("/Activity;component/image/Ежедневные.png", UriKind.Relative));
                        break;
                    case QuestType.Weekly:
                        typeImage.Source = new BitmapImage(new Uri("/Activity;component/image/Еженедельный.png", UriKind.Relative));
                        break;
                    case QuestType.Other:
                        typeImage.Source = new BitmapImage(new Uri("/Activity;component/image/Необычный.png", UriKind.Relative));
                        break;
                }
            }
        }
        public int questCounter
        {
            get { return int.Parse(questProgress.Value.ToString()); }
            set { questProgress.Value = value; }
        }
        public int maxQuestCounter
        {
            get { return int.Parse(questProgress.Maximum.ToString()); }
            set {
                questProgress.Maximum = value;
                if (value == 0)
                {
                    questProgressParent.Visibility = Visibility.Collapsed;
                    labelCounter.Visibility = Visibility.Collapsed;
                }
            }
        }
        public string leftText
        {
            get { return textBlockLeft.Text; }
            set { textBlockLeft.Text = value.Replace("{n}", "\n"); }
        }
        public string rightText
        {
            get { return textBlockRight.Text; }
            set { textBlockRight.Text = value.Replace("{n}", "\n"); }
        }

        public Quest()
        {
            InitializeComponent();
            if (Properties.Settings.Default.questSaves != null) questCounter = int.Parse(Properties.Settings.Default.questSaves[questId]?.ToString());
            questId++;
        }

        private void progressClick(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "plus")
                questCounter += 1;
            else
                questCounter -= 1;
        }


        public enum QuestType
        {
            Daily,
            Weekly,
            Other
        };
    }
}
