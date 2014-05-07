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
                _contactEditViewModel.EingabeFirma = s.Firma;
                _contactEditViewModel.EingabeTitel = s.Titel;
                _contactEditViewModel.EingabeVorname = s.Vorname;
                _contactEditViewModel.EingabeNachname = s.Nachname;
                _contactEditViewModel.EingabeSuffix = s.Suffix;
                _contactEditViewModel.EingabeGeburtstag = s.Geburtstag;
                _contactEditViewModel.EingabeUID = s.UID;
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

        //private string _eingabeVorname;
        //public string EingabeVorname
        //{
        //    get
        //    {
        //        return _eingabeVorname;
        //    }
        //    set
        //    {
        //        if (_eingabeVorname != value)
        //        {
        //            _eingabeVorname = value;
        //            SearchCommand.OnCanExecuteChanged();
        //            NotifyStateChanged();
        //            OnPropertyChanged("EingabeVorname");
        //        }
        //    }
        //}

        //private string _eingabeNachname;
        //public string EingabeNachname
        //{
        //    get
        //    {
        //        return _eingabeNachname;
        //    }
        //    set
        //    {
        //        if (_eingabeNachname != value)
        //        {
        //            _eingabeNachname = value;
        //            SearchCommand.OnCanExecuteChanged();
        //            NotifyStateChanged();
        //            OnPropertyChanged("EingabeNachname");
        //        }
        //    }
        //}

        //private string _eingabeFirma;
        //public string EingabeFirma
        //{
        //    get
        //    {
        //        return _eingabeFirma;
        //    }
        //    set
        //    {
        //        if (_eingabeFirma != value)
        //        {
        //            _eingabeFirma = value;
        //            SearchCommand.OnCanExecuteChanged();
        //            OnPropertyChanged("EingabeFirma");
        //        }
        //    }
        //}

        //// IsEnabled="{Binding FirmaIsEnabled}
        ////{Binding EingabeVorname, UpdateSourceTrigger=PropertyChanged}
        //public bool FirmaIsEnabled
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(EingabeVorname) || string.IsNullOrWhiteSpace(EingabeNachname))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        //public bool NameIsEnabled
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(EingabeFirma))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}


        /*
         * private string _eingabeTitel;
        public string EingabeTitel
        {
            get
            {
                return _eingabeTitel;
            }
            set
            {
                if (_eingabeTitel != value)
                {
                    _eingabeTitel = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeTitel");
                }
            }
        }

        private string _eingabeSuffix;
        public string EingabeSuffix
        {
            get
            {
                return _eingabeSuffix;
            }
            set
            {
                if (_eingabeSuffix != value)
                {
                    _eingabeSuffix = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeSuffix");
                }
            }
        }

        private string _eingabeGeburtstag;
        public string EingabeGeburtstag
        {
            get
            {
                return _eingabeGeburtstag;
            }
            set
            {
                if (_eingabeGeburtstag != value)
                {
                    _eingabeGeburtstag = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeGeburtstag");
                }
            }
        }

        private string _eingabeUID;
        public string EingabeUID
        {
            get
            {
                return _eingabeUID;
            }
            set
            {
                if (_eingabeUID != value)
                {
                    _eingabeUID = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeUID");
                }
            }
        }

        private string _eingabeStrasse;
        public string EingabeStrasse
        {
            get
            {
                return _eingabeStrasse;
            }
            set
            {
                if (_eingabeStrasse != value)
                {
                    _eingabeStrasse = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeStrasse");
                }
            }
        }

        private string _eingabePLZ;
        public string EingabePLZ
        {
            get
            {
                return _eingabePLZ;
            }
            set
            {
                if (_eingabePLZ != value)
                {
                    _eingabePLZ = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabePLZ");
                }
            }
        }

        private string _eingabeOrt;
        public string EingabeOrt
        {
            get
            {
                return _eingabeOrt;
            }
            set
            {
                if (_eingabeOrt != value)
                {
                    _eingabeOrt = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeOrt");
                }
            }
        }
         * */
    }
}
