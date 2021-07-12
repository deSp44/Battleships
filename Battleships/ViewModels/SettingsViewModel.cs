using Battleships.Commands;
using Battleships.Models;
using Battleships.Properties;
using Battleships.Stores;
using System;
using System.IO;
using System.Media;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    class SettingsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly BackgroundMusic _backgroundMusic = new BackgroundMusic();
        private readonly SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));

        public SettingsViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            BackCommand = new RelayCommand(Back);
        }



        public ICommand BackCommand { get; set; }


        private bool _muteIsChecked = Settings.Default.UserMuteIsChecked;
        public bool MuteIsChecked { get { return _muteIsChecked; } set { _muteIsChecked = value; OnPropertyChanged(); _backgroundMusic.Mute(_muteIsChecked); } }

        private int _volumeValue = Settings.Default.UserMusicVolume;
        public int VolumeValue { get { return _volumeValue; } set { _volumeValue = value; OnPropertyChanged(); _backgroundMusic.ChangeVolume(_volumeValue); } }

        private void Back(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);

            
        }
    }
}
