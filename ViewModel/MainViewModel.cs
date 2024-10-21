using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaming_Voice_Assistant.Core;

namespace Gaming_Voice_Assistant.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand CustomizationViewCommand { get; set; }
        public RelayCommand CommandsViewCommand { get; set; }

        public CustomizationViewModel CustomizationViewModel { get; set; }
        public CommandsViewModel CommandsViewModel { get; set; }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CustomizationViewModel = new CustomizationViewModel();
            CommandsViewModel = new CommandsViewModel();

            currentView = CommandsViewModel;

            CustomizationViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomizationViewModel;
            });

            CommandsViewCommand = new RelayCommand(o =>
            {
                CurrentView = CommandsViewModel;
            });
        }
    }
}
