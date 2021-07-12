using Battleships.Commands;
using Battleships.Models;
using Battleships.Stores;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace Battleships.ViewModels
{
    class PlayViewModel : ViewModelBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));

        public PlayViewModel(NavigationStore navigationStore)
        {
            Clients = new ObservableCollection<NewClients> { new NewClients { IpAddress = "192.168.0.192", Username = "deSp", Status = true } };


            _navigationStore = navigationStore;

            BackCommand = new RelayCommand(Back);
            JoinCommand = new RelayCommand(Join);
            SearchServersCommand = new RelayCommand(SearchServers);
        }


        public ICommand BackCommand { get; set; }
        public ICommand JoinCommand { get; set; }
        public ICommand SearchServersCommand { get; set; }



        private ObservableCollection<NewClients> _clients;
        public ObservableCollection<NewClients> Clients
        {
            get { return _clients; }
            set { _clients = value; OnPropertyChanged(); }
        }

        private Visibility _visibilityMode = Visibility.Hidden;
        public Visibility VisibilityMode
        {
            get { return _visibilityMode; }
            set { _visibilityMode = value; OnPropertyChanged(); }
        }

        private void Back(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void Join(object obj)
        {
            _buttonClickSound.Play();
            _navigationStore.CurrentViewModel = new GamePreparationViewModel(_navigationStore);
            
        }

        private void SearchServers(object obj)
        {
            
        }
    }
}
