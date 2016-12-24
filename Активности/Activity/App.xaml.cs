using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Activity
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ResourceDictionary dict = new ResourceDictionary();
        public App()
        {
            dict.Source = new Uri("Properties/DataBase.xaml", UriKind.Relative);
        }
    }
}
