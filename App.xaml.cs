using Battleships.Models;
using Battleships.Stores;
using Battleships.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Battleships
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore); // FIRST VIEW OF APP

            var backgroundMusic = new BackgroundMusic();
            backgroundMusic.PlayMusic();


            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore) // ASSIGN A VIEW

            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
