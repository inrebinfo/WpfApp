using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels
{
    public class CompanySearchViewModel : SearchViewModel
    {
        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        private ContactEditViewModel _contactEditViewModel;
        private Window _wnd;

        public CompanySearchViewModel(List<ContactObject> list, ContactEditViewModel model, Window wnd)
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
            _contactEditViewModel = model;
            _wnd = wnd;

            foreach (var item in list)
            {
                this.Items.Add(new ContactViewModel(item));
            }
        }

        public override void Search()
        {
        }

        public override bool CanSearch()
        {
            return true;
        }

        public override void NewContactWindow()
        {
        }

        public override bool CanNewContactWindow()
        {
            return true;
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        public override void ActivateItems()
        {
            var items = SelectedViewModels;

            foreach (ContactViewModel s in items)
            {
                _contactEditViewModel.ReceiveCompany(s);
                _wnd.Close();
            }
        }

        public void NotifyStateChanged()
        {
            //OnPropertyChanged("IsFirma");
            //OnPropertyChanged("CanEditPerson");
            OnPropertyChanged("FirmaIsEnabled");
        }

        public override void NewInvoiceWindow()
        {
        }

        public override bool CanNewInvoiceWindow()
        {
            return true;
        }
    }
}
