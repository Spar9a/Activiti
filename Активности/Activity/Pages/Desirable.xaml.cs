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
        }
    }
}
