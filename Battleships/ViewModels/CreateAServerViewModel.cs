using System;
using System.IO;
using System.Media;
using System.Windows.Input;
using Battleships.Commands;
using Battleships.Stores;

namespace Battleships.ViewModels
{
    public class CreateAServerViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));

        public ICommand BackCommand { get; }
        public ICommand CreateCommand { get; set; }

        public CreateAServerViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            BackCommand = new RelayCommand(Back);
            CreateCommand = new RelayCommand(Create);
        }

        private void Back(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void Create(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new ServerCreatedViewModel(_navigationStore);
        }
    }
}