using Battleships.Models;
using Battleships.Stores;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Media;
using System.Windows;

namespace Battleships.ViewModels
{
    class GamePreparationViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly SoundPlayer _buttonClickSound = new SoundPlayer(Path.Combine(Environment.CurrentDirectory + @"/media/button_sound.wav"));
        public GamePreparationViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Application.Current.MainWindow.Width = 1200;
            Application.Current.MainWindow.Left = 300;
        }


        private ObservableCollection<BattlefieldCell> _battlefield;
        public ObservableCollection<BattlefieldCell> Battlefield
        {
            get { return _battlefield; }
            set { _battlefield = value; OnPropertyChanged(); }
        }
    }
}
