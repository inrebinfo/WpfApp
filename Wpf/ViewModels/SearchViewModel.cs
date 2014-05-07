using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Wpf.ViewModels
{
    public abstract class SearchViewModel : ViewModel
    {
        public SearchViewModel()
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
        }


        private ICommandViewModel _searchCommand;
        public ICommandViewModel SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new SimpleCommandViewModel(
                        "Suchen",
                        "Startet eine Suche",
                        Search,
                        CanSearch);
                }
                return _searchCommand;
            }
        }

        private ICommandViewModel _newContactCommand;
        public ICommandViewModel NewContactCommand
        {
            get
            {
                if (_newContactCommand == null)
                {
                    _newContactCommand = new SimpleCommandViewModel(
                        "Suchen",
                        "Startet eine Suche",
                        NewContactWindow,
                        CanNewContactWindow);
                }
                return _newContactCommand;
            }
        }

        public abstract void Search();
        public abstract bool CanSearch();

        public abstract void NewContactWindow();
        public abstract bool CanNewContactWindow();

        public abstract GridDisplayConfiguration DisplayedColumns { get; }

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        public virtual void ActivateItems()
        {
            
        }
    }
}
