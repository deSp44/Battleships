using Battleships.Commands;
using Battleships.Models;
using Battleships.Stores;
using Battleships.Views.SwitchingViews;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));

        public HomeViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;


            PlayCommand = new RelayCommand(Play);
            CreateAServerCommand = new RelayCommand(CreateAServer);
            CreditsCommand = new RelayCommand(AsyncCredits);
            OptionsCommand = new RelayCommand(Options);
            ExitCommand = new RelayCommand(Exit);
        }


        public ICommand PlayCommand { get; set; }
        public ICommand CreateAServerCommand { get; set; }
        public ICommand CreditsCommand { get; set; }
        public ICommand OptionsCommand { get; set; }
        public ICommand ExitCommand { get; set; }


        private async void AsyncCredits(object obj)
        {
            _buttonClickSound.Play();
            var metroWindow = Application.Current.MainWindow as MetroWindow;

            MetroDialogSettings dialogSettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Go to site"
            };

            var dialog = await metroWindow.ShowMessageAsync("Credits...", $"Game created by deSp.\n2021\n\nhttps://github.com/deSp44\n\nIf you want to open the browser and go to the website, click '{dialogSettings.AffirmativeButtonText}' button.", MessageDialogStyle.AffirmativeAndNegative, dialogSettings);


            if (dialog == MessageDialogResult.Affirmative)
            {
                System.Diagnostics.Process.Start("https://github.com/deSp44");
            }
        }
        private void Exit(object obj)
        {
            _buttonClickSound.Play();
            Application.Current.Shutdown();
        }

        private void Options(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore);
        }

        private void CreateAServer(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new CreateAServerViewModel(_navigationStore);
        }
        
        private void Play(object obj)
        {
            _buttonClickSound.Play();
        }
    }
}
