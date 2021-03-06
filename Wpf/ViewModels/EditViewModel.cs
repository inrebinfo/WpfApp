﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Wpf.ViewModels
{
    public abstract class EditViewModel : ViewModel
    {
        public EditViewModel()
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
        }

       
        private ICommandViewModel _editCommand;
        public ICommandViewModel EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new SimpleCommandViewModel(
                        "Edit", 
                        "Editet", 
                        Edit,
                        CanEdit);
                }
                return _editCommand;
            }
        }

        private ICommandViewModel _searchCommand;
        public ICommandViewModel SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new SimpleCommandViewModel(
                        "Suche",
                        "Sucht",
                        Search,
                        CanSearch);
                }
                return _searchCommand;
            }
        }

        public abstract void Search();
        public abstract bool CanSearch();

        public abstract void Edit();
        public abstract bool CanEdit();

        public abstract GridDisplayConfiguration DisplayedColumns { get; }

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        public virtual void ActivateItems()
        {
            
        }
    }
}
