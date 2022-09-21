using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using LeagueBuddy.Preload;

namespace LeagueBuddy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();

            PreloadWindow preload = new();
            preload.Closed += (s, e) =>
            {
                MainWindow.Show();
            };

            preload.Show();
        }
    }
}
