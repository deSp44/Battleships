using Battleships.Commands;
using Battleships.Stores;
using Battleships.ViewModels;
using Battleships.Views.SwitchingViews;
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
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}