using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Wpf.ViewModels;
using System.Windows;
using System.Globalization;

namespace Wpf.ViewModels
{
    public class InvoiceSearchViewModel : SearchViewModel
    {
        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        private InvoiceEditViewModel _invoiceEditViewModel;


        public InvoiceSearchViewModel()
        {
            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();
            DatumBis = DateTime.Now;
            DatumVon = DateTime.Now;
        }

        public override void Search()
        {
            //kunde,datevon,datebis,preisvon,preisbis

            string datevon;
            string datebis;
            string preisvon;
            string preisbis;

            if (DatumVon == null)
                datevon = "1900-01-01 00:00:00";
            else
                datevon = DatumVon.ToString("yyyy-MM-dd HH:MM:ss");

            if (DatumBis == null)
                datebis = "2100-12-31 23:59:59";
            else
                datebis = DatumBis.ToString("yyyy-MM-dd HH:MM:ss");

            if (string.IsNullOrEmpty(PreisVon))
                preisvon = "0";
            else
                preisvon = PreisVon;

            if (string.IsNullOrEmpty(PreisBis))
                preisbis = "9999999999";
            else
                preisbis = PreisBis;


            string sString = EingabeKunde + "," + datevon + "," + datebis + "," + preisvon + "," + preisbis;
            Proxy prox = new Proxy();
            prox.SearchInvoice(sString);
            var result = prox.getInvoiceList;

            this.Items.Clear();

            foreach (var item in result)
            {
                this.Items.Add(new InvoiceViewModel(item));
            }
        }

        public override bool CanSearch()
        {
            return true;
            //return !string.IsNullOrWhiteSpace(EingabeKunde);
        }


        public override void NewInvoiceWindow()
        {
            _invoiceEditViewModel = new InvoiceEditViewModel();


            InvoiceForm form = new InvoiceForm(_invoiceEditViewModel);
            form.Show();
        }

        public override bool CanNewInvoiceWindow()
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

            foreach (InvoiceViewModel s in items)
            {

                _invoiceEditViewModel = new InvoiceEditViewModel(s.ID);

                try
                {
                    _invoiceEditViewModel.ID = s.ID;
                    //_invoiceEditViewModel.DatumErstellung = DateTime.ParseExact(s.ErstellungsDatum, "yyyy-MM-dd HH:MM:ss", CultureInfo.InvariantCulture);
                    //_invoiceEditViewModel.DatumFaellig = DateTime.ParseExact(s.FaelligkeitsDatum, "yyyy-MM-dd HH:MM:ss", CultureInfo.InvariantCulture);
                    _invoiceEditViewModel.DatumErstellung = s.ErstellungsDatum;
                    _invoiceEditViewModel.DatumFaellig = s.FaelligkeitsDatum;
                    _invoiceEditViewModel.Kommentar = s.Kommentar;
                    _invoiceEditViewModel.Nachricht = s.Nachricht;
                    InvoiceForm form = new InvoiceForm(_invoiceEditViewModel);
                    form.Show();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }


            }
        }

        public void NotifyStateChanged()
        {
            //OnPropertyChanged("IsFirma");
            //OnPropertyChanged("CanEditPerson");
            //OnPropertyChanged("EingabeKunde");
        }

        private string _eingabeKunde;
        public string EingabeKunde
        {
            get
            {
                return _eingabeKunde;
            }
            set
            {
                if (_eingabeKunde != value)
                {
                    _eingabeKunde = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("EingabeKunde");
                }
            }
        }

        private DateTime _datumVon;
        public DateTime DatumVon
        {
            get
            {
                return _datumVon;
            }
            set
            {
                if (_datumVon != value)
                {
                    _datumVon = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("DatumVon");
                }
            }
        }

        private DateTime _datumBis;
        public DateTime DatumBis
        {
            get
            {
                return _datumBis;
            }
            set
            {
                if (_datumBis != value)
                {
                    _datumBis = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("DatumBis");
                }
            }
        }

        private string _preisVon;
        public string PreisVon
        {
            get
            {
                return _preisVon;
            }
            set
            {
                if (_preisVon != value)
                {
                    _preisVon = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("PreisVon");
                }
            }
        }

        private string _preisBis;
        public string PreisBis
        {
            get
            {
                return _preisBis;
            }
            set
            {
                if (_preisBis != value)
                {
                    _preisBis = value;
                    SearchCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("PreisBis");
                }
            }
        }

        public override void NewContactWindow()
        {

        }

        public override bool CanNewContactWindow()
        {
            return true;
        }
    }
}
