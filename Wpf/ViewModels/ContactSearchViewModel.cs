using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {
        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        private ContactEditViewModel _contactEditViewModel;


        public ContactSearchViewModel()
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
        }


        public override void Search()
        {
            Proxy prox = new Proxy();
            prox.SearchContacts(SearchText);
            var result = prox.getList;

            this.Items.Clear();

            foreach (var item in result)
            {
                this.Items.Add(new ContactViewModel(item));
            }
        }

        public override bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(SearchText);
        }

        public override void NewContactWindow()
        {
            _contactEditViewModel = new ContactEditViewModel();

            
            _contactEditViewModel._isEdit = false;

            ContactForm form = new ContactForm(_contactEditViewModel);
            form.Show();
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
                //_contactEditViewModel.SearchText = s.Companyname;

                //_contactEditViewModel.ColorGreen();

                _contactEditViewModel = new ContactEditViewModel();

                _contactEditViewModel.ID = s.ID;
                if (!string.IsNullOrWhiteSpace(s.Vorname))
                {
                    _contactEditViewModel.EingabeFirmaKunde = s.Firma;
                    _contactEditViewModel.EingabeTitel = s.Titel;
                    _contactEditViewModel.EingabeVorname = s.Vorname;
                    _contactEditViewModel.EingabeNachname = s.Nachname;
                    _contactEditViewModel.EingabeSuffix = s.Suffix;
                    _contactEditViewModel.EingabeGeburtstag = s.Geburtstag;
                    _contactEditViewModel._companyID = Convert.ToInt32(s.FK_Kontakt);
                }
                else if (!string.IsNullOrWhiteSpace(s.Firma))
                {
                    _contactEditViewModel.EingabeFirma = s.Firma;
                    _contactEditViewModel.EingabeUID = s.UID;
                }
                _contactEditViewModel.EingabeStrasse = s.Strasse;
                _contactEditViewModel.EingabePLZ = s.PLZ;
                _contactEditViewModel.EingabeOrt = s.Ort;
                _contactEditViewModel._isEdit = true;

                ContactForm form = new ContactForm(_contactEditViewModel);
                form.Show();


            }
        }

        public void NotifyStateChanged()
        {
            //OnPropertyChanged("IsFirma");
            //OnPropertyChanged("CanEditPerson");
            OnPropertyChanged("SearchText");
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("SearchText");
                }
            }
        }

        public override void NewInvoiceWindow()
        { }

        public override bool CanNewInvoiceWindow()
        {
            return true;
        }
    }
}
