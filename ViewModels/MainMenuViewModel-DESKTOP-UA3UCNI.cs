using Battleships.Commands;
using Battleships.Views.SwitchingViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public MainMenuViewModel()
        {
            CurrentView = new MainMenuView();

            PlayCommand = new RelayCommand(Play);
            CreateAServerCommand = new RelayCommand(CreateAServer);
            CreditsCommand = new RelayCommand(AsyncCredits);
            ExitCommand = new RelayCommand(Exit);
        }

        public ICommand PlayCommand { get; set; }
        public ICommand CreateAServerCommand { get; set; }
        public ICommand CreditsCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged("CurrentView"); }
        }

        private string _setDataContext;

        public string SetDataContext
        {
            get { return _setDataContext; }
            set { _setDataContext = value; OnPropertyChanged(); }
        }
        private async void AsyncCredits(object obj)
        {
            var mySettings = new MetroDialogSettings
            {
                AffirmativeButtonText = "Open site"
            };

            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Credits...", "Game created by deSp.\n2021\n\nhttps://github.com/deSp44\n\nIf you want to open the browser and go to the website, click 'OK'", MessageDialogStyle.AffirmativeAndNegative, mySettings);

            


            if (dialog == MessageDialogResult.Affirmative)
            {
                System.Diagnostics.Process.Start("https://github.com/deSp44");
            }
        }
        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void CreateAServer(object obj)
        {

        }
        
        private void Play(object obj)
        {
            CurrentView = new CreateAServerView();
            SetDataContext = "";
        }
    }
}
