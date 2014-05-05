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

        public ContactSearchViewModel(string searchName)
        {
            //SearchText = searchName;

            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
        }

        public ContactSearchViewModel(ContactEditViewModel contactEditViewModel, string searchName)
        {
            _contactEditViewModel = contactEditViewModel;

            //SearchText = searchName;

            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();

            Search();
        }


        public override void Search()
        {
            Proxy prox = new Proxy();
            var result = prox.getList;

            this.Items.Clear();

            foreach (var item in result)
            {
                this.Items.Add(new ContactViewModel(item));
            }
        }

        public override bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);
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

                _contactEditViewModel.EingabeFirma = s.Vorname;

                ContactForm form = new ContactForm(_contactEditViewModel);
                form.Show();

                //MessageBox.Show(s.Vorname + " " + s.Nachname + " " + s.Firma);

            }
        }

        private string _eingabeVorname;
        public string EingabeVorname
        {
            get
            {
                return _eingabeVorname;
            }
            set
            {
                if (_eingabeVorname != value)
                {
                    _eingabeVorname = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeVorname");
                }
            }
        }

        private string _eingabeNachname;
        public string EingabeNachname
        {
            get
            {
                return _eingabeNachname;
            }
            set
            {
                if (_eingabeNachname != value)
                {
                    _eingabeNachname = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeNachname");
                }
            }
        }

        private string _eingabeFirma;
        public string EingabeFirma
        {
            get
            {
                return _eingabeFirma;
            }
            set
            {
                if (_eingabeFirma != value)
                {
                    _eingabeFirma = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeFirma");
                }
            }
        }
    }
}
