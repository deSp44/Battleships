using Battleships.Commands;
using Battleships.Stores;
using System;
using System.IO;
using System.Media;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    class ServerCreatedViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));

        public ServerCreatedViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            BackCommand = new RelayCommand(Back);
        }

        

        public ICommand BackCommand { get; }

        private void Back(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new CreateAServerViewModel(_navigationStore);
        }
    }
}
