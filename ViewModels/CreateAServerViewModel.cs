using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Battleships.Commands;
using Battleships.Stores;
using Battleships.Views.SwitchingViews;

namespace Battleships.ViewModels
{
    public class CreateAServerViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public CreateAServerViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            BackCommand = new RelayCommand(Back);
        }

        public ICommand BackCommand { get; }


        private void Back(object obj)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        } 
    }
}
