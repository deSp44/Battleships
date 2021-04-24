using Battleships.Commands;
using Battleships.ViewModels;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Battleships
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            PlayCommand = new RelayCommand(Play);
            CreateAServerCommand = new RelayCommand(CreateAServer);
            CreditsCommand = new RelayCommand(AsyncCredits);
            ExitCommand = new RelayCommand(Exit);
        }


        public ICommand PlayCommand { get; set; }
        public ICommand CreateAServerCommand { get; set; }
        public ICommand CreditsCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        private void Play(object obj)
        {
        }
        private void CreateAServer(object obj)
        {
        }
        private async void AsyncCredits(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Credits...", "Game created by deSp.\n2021\n\nhttps://github.com/deSp44\n\nIf you want to open the browser and go to the website, click 'OK'", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog == MessageDialogResult.Affirmative)
            {
                System.Diagnostics.Process.Start("https://github.com/deSp44");
            }
        }
        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}