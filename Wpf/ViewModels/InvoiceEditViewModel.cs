using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels
{
    public class InvoiceEditViewModel : EditViewModel
    {
        private int _companyID;
        public bool _isEdit { get; set; }
        private Window _wnd;
        private double _nettoFull = 0;
        private double _bruttoFull = 0;

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        public InvoiceEditViewModel()
        {
            _isEdit = true;

            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();

            DatumErstellung = DateTime.Now;
            DatumFaellig = DateTime.Now;
        }

        public InvoiceEditViewModel(string id)
        {
            _isEdit = false;
            FillList(id);
        }


        private void FillList(string id)
        {
            Proxy prox = new Proxy();
            prox.SearchInvoiceLines(id);
            var result = prox.getInvoiceLinesList;

            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();

            this.Items.Clear();

            foreach (var item in result)
            {
                _nettoFull += (Convert.ToDouble(item.Stkpreis) * Convert.ToDouble(item.Menge));

                _bruttoFull += (Convert.ToDouble(item.Stkpreis) * Convert.ToDouble(item.Menge)) * (1 + (Convert.ToDouble(item.UST) / 100));

                this.Items.Add(new InvoiceLineViewModel(item));
            }
        }

        public void AddNewLine()
        {
            InvoiceLineObject obj = new InvoiceLineObject();
            obj.Menge = EingabeMenge;
            obj.Stkpreis = EingabeStkpreis;
            obj.UST = EingabeUST;

            this.Items.Add(new InvoiceLineViewModel(obj));

            Nettogesamt = (Convert.ToDouble(Nettogesamt)+(Convert.ToDouble(obj.Menge) * Convert.ToDouble(obj.Stkpreis))).ToString();

            double brutto = Convert.ToDouble(Bruttogesamt);

            double multiplikator = (1 + (Convert.ToDouble(obj.UST) / 100));

            double netto = Convert.ToDouble(obj.Menge) * Convert.ToDouble(obj.Stkpreis);

            Bruttogesamt = (brutto+(netto * multiplikator)).ToString();
        }

        public override void Edit()
        {

            //irgendwie summe aus einträgen rechnen und in .Summe speichern

            
            /*Proxy prox = new Proxy();
            prox.SaveContact(contactToSave);*/

            //_wnd.Close();
            this.Close = true;
        }

        public override bool CanEdit()
        {
            /*return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);*/
            return true;
        }

        public override void Search()
        {
            //firmensuche
            Proxy prox = new Proxy();
            prox.SearchCompany(EingabeKunde);
            var result = prox.getList;

            this.Items.Clear();

            if (result.Count == 1)
            {
                _companyID = Convert.ToInt32(result[0].ID);
                EingabeKunde = result[0].Firmenname;
                MessageBox.Show("genau 1");
            }
            else if (result.Count > 1)
            {
                //CompanySearch wnd = new CompanySearch(result, this);
                //wnd.Show();
                MessageBox.Show("mehrere");
            }
            else
            {
                MessageBox.Show("keine");
            }
        }

        public override bool CanSearch()
        {
            /*return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);*/
            return true;
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        public void NotifyStateChanged()
        {
            //OnPropertyChanged("EingabeFirmaKunde");
            OnPropertyChanged("IsFirma");
            OnPropertyChanged("CanEditFirma");
            OnPropertyChanged("CanEditPerson");
        }

        public bool _close = false;
        public bool Close
        {

            get
            {
                return _close;
            }
            set
            {
                _close = value;
                OnPropertyChanged("Close");
            }
        }

        public void ReceiveCompany(ContactViewModel model)
        {
            /*EingabeFirmaKunde = model.Firma;
            _companyID = Convert.ToInt32(model.ID);*/
        }

        // firma (Selbst) firmenzuweisung richtig setzen/filtern
        // deaktivieren properties

        public bool? IsFirma
        {
            get
            {
                /*if (string.IsNullOrWhiteSpace(EingabeNachname) && string.IsNullOrWhiteSpace(EingabeVorname) && string.IsNullOrWhiteSpace(EingabeFirma))
                    return null;

                return !string.IsNullOrWhiteSpace(EingabeFirma);*/
                return true;
            }
        }

        /// <summary>
        /// Enable or Disable Groupbox
        /// </summary>
        public bool CanEditPerson
        {
            get
            {
                return IsFirma == null || IsFirma == false;
            }
        }

        public bool CanEditFirma
        {
            get
            {
                return IsFirma == null || IsFirma == true;
            }
        }

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("ID");
                    NotifyStateChanged();
                }
            }
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
                    OnPropertyChanged("EingabeKunde");
                    NotifyStateChanged();
                }
            }
        }

        private DateTime _datumErstellung;
        public DateTime DatumErstellung
        {
            get
            {
                return _datumErstellung;
            }
            set
            {
                if (_datumErstellung != value)
                {
                    _datumErstellung = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("DatumErstellung");
                    NotifyStateChanged();
                }
            }
        }

        private DateTime _datumFaellig;
        public DateTime DatumFaellig
        {
            get
            {
                return _datumFaellig;
            }
            set
            {
                if (_datumFaellig != value)
                {
                    _datumFaellig = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("DatumFaellig");
                    NotifyStateChanged();
                }
            }
        }

        private string _nachricht;
        public string Nachricht
        {
            get
            {
                return _nachricht;
            }
            set
            {
                if (_nachricht != value)
                {
                    _nachricht = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Nachricht");
                    NotifyStateChanged();
                }
            }
        }

        private string _kommentar;
        public string Kommentar
        {
            get
            {
                return _kommentar;
            }
            set
            {
                if (_kommentar != value)
                {
                    _kommentar = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Kommentar");
                    NotifyStateChanged();
                }
            }
        }

        // bindings liste

        private string _menge;
        public string Menge
        {
            get
            {
                return _menge;
            }
            set
            {
                if (_menge != value)
                {
                    _menge = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Menge");
                    NotifyStateChanged();
                }
            }
        }

        private string _stkpreis;
        public string Stkpreis
        {
            get
            {
                return _stkpreis;
            }
            set
            {
                if (_stkpreis != value)
                {
                    _stkpreis = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Stkpreis");
                    NotifyStateChanged();
                }
            }
        }

        private string _ust;
        public string UST
        {
            get
            {
                return _ust;
            }
            set
            {
                if (_ust != value)
                {
                    _ust = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("UST");
                    NotifyStateChanged();
                }
            }
        }

        //netto brutto 

        public string Nettogesamt
        {
            get
            {
                return _nettoFull.ToString();
            }
            set
            {
                if (_nettoFull != Convert.ToDouble(value))
                {
                    _nettoFull = Convert.ToDouble(value);
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Nettogesamt");
                    NotifyStateChanged();
                }
            }
        }

        public string Bruttogesamt
        {
            get
            {
                return _bruttoFull.ToString();
            }
            set
            {
                if (_bruttoFull != Convert.ToDouble(value))
                {
                    _bruttoFull = Convert.ToDouble(value);
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("Bruttogesamt");
                    NotifyStateChanged();
                }
            }
        }

        private ICommandViewModel _addNewLineCommand;
        public ICommandViewModel AddNewLineCommand
        {
            get
            {
                if (_addNewLineCommand == null)
                {
                    _addNewLineCommand = new SimpleCommandViewModel(
                        "Edit",
                        "Editet",
                        AddNewLine,
                        CanEdit);
                }
                return _addNewLineCommand;
            }
        }

        private string _eingabeMenge;
        public string EingabeMenge
        {
            get
            {
                return _eingabeMenge;
            }
            set
            {
                if (_eingabeMenge != value)
                {
                    _eingabeMenge = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeMenge");
                    NotifyStateChanged();
                }
            }
        }

        private string _eingabeStkpreis;
        public string EingabeStkpreis
        {
            get
            {
                return _eingabeStkpreis;
            }
            set
            {
                if (_eingabeStkpreis != value)
                {
                    _eingabeStkpreis = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeStkpreis");
                    NotifyStateChanged();
                }
            }
        }

        private string _eingabeUST;
        public string EingabeUST
        {
            get
            {
                return _eingabeUST;
            }
            set
            {
                if (_eingabeUST != value)
                {
                    _eingabeUST = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeUST");
                    NotifyStateChanged();
                }
            }
        }
    }
}
