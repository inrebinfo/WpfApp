using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Wpf.ViewModels
{
    public class InvoiceEditViewModel : EditViewModel
    {
        private int _companyID { get; set; }
        public bool _isEdit { get; set; }
        private double _nettoFull = 0;
        private double _bruttoFull = 0;

        public ObservableCollection<ViewModel> Items { get; private set; }
        public ObservableCollection<ViewModel> SelectedViewModels { get; private set; }

        private List<InvoiceLineObject> invoicelines = new List<InvoiceLineObject>();

        public InvoiceEditViewModel()
        {
            _isEdit = true;
            _nettoFull = 0;
            _bruttoFull = 0;

            Items = new ObservableCollection<ViewModel>();
            SelectedViewModels = new ObservableCollection<ViewModel>();

            DatumErstellung = DateTime.Now;
            DatumFaellig = DateTime.Now;
            ColorTransparent();
        }

        public InvoiceEditViewModel(string id)
        {
            _nettoFull = 0;
            _bruttoFull = 0;
            _isEdit = false;
            FillList(id);
            ColorTransparent();
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
                this.Items.Add(new InvoiceLineViewModel(item));
                invoicelines.Add(item);

                Nettogesamt = (Convert.ToDouble(Nettogesamt) + (Convert.ToDouble(item.Menge) * Convert.ToDouble(item.Stkpreis))).ToString();

                double brutto = Convert.ToDouble(Bruttogesamt);

                double multiplikator = (1 + (Convert.ToDouble(item.UST) / 100));

                double netto = Convert.ToDouble(item.Menge) * Convert.ToDouble(item.Stkpreis);

                Bruttogesamt = (brutto + (netto * multiplikator)).ToString();
            }
        }

        public void AddNewLine()
        {
            InvoiceLineObject obj = new InvoiceLineObject();
            obj.Menge = EingabeMenge;
            obj.Stkpreis = EingabeStkpreis;
            obj.UST = EingabeUST;

            this.Items.Add(new InvoiceLineViewModel(obj));
            invoicelines.Add(obj);

            Nettogesamt = (Convert.ToDouble(Nettogesamt)+(Convert.ToDouble(obj.Menge) * Convert.ToDouble(obj.Stkpreis))).ToString();

            double brutto = Convert.ToDouble(Bruttogesamt);

            double multiplikator = (1 + (Convert.ToDouble(obj.UST) / 100));

            double netto = Convert.ToDouble(obj.Menge) * Convert.ToDouble(obj.Stkpreis);

            Bruttogesamt = (brutto+(netto * multiplikator)).ToString();
        }

        public override void Edit()
        {
            InvoiceObject invoiceObj = new InvoiceObject();
            invoiceObj.ErstellungsDatum = DatumErstellung;
            invoiceObj.FaelligkeitsDatum = DatumFaellig;
            invoiceObj.Kommentar = Kommentar;
            invoiceObj.Nachricht = Nachricht;
            invoiceObj.InvoiceLines = invoicelines;
            invoiceObj.Summe = Nettogesamt;
            invoiceObj.FK_Kontakt = _companyID.ToString();

            Proxy prox = new Proxy();
            prox.SaveInvoice(invoiceObj);

            this.Close = true;
        }

        public override bool CanEdit()
        {
            return true;
        }

        public override void Search()
        {
            //firmensuche
            Proxy prox = new Proxy();
            prox.SearchContacts(EingabeKunde);
            var result = prox.getList;

            this.Items.Clear();

            if (result.Count == 1)
            {
                _companyID = Convert.ToInt32(result[0].ID);
                EingabeKunde = result[0].Firmenname;
                ColorGreen();
            }
            else if (result.Count > 1)
            {
                ColorRed();
                CompanySearch wnd = new CompanySearch(result, this);
                wnd.Show();
            }
            else
            {
                ColorRed();
            }
        }

        public override bool CanSearch()
        {
            return true;
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        public void NotifyStateChanged()
        {
            OnPropertyChanged("IsEditable");
            OnPropertyChanged("CanEditInvoice");
            OnPropertyChanged("CanPrintInvoice");
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
            if (!string.IsNullOrWhiteSpace(model.Vorname))
            {
                EingabeKunde = model.Vorname + " " + model.Nachname;
            }
            else
            {
                EingabeKunde = model.Firma;
            }
            _companyID = Convert.ToInt32(model.ID);
            ColorGreen();
        }

        // firma (Selbst) firmenzuweisung richtig setzen/filtern
        // deaktivieren properties

        public bool? IsEditable
        {
            get
            {
                return !_isEdit;
            }
        }

        /// <summary>
        /// Enable or Disable Groupbox
        /// </summary>
        public bool CanEditInvoice
        {
            get
            {
                return IsEditable == null || IsEditable == false;
            }
        }

        public bool CanPrintInvoice
        {
            get
            {
                return IsEditable == null || IsEditable == true;
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

        private string _fkkontakt;
        public string FK_Kontakt
        {
            get
            {
                return _fkkontakt;
            }
            set
            {
                if (_fkkontakt != value)
                {
                    _fkkontakt = value;
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("FK_Kontakt");
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

        private ICommandViewModel _delFirmaCommand;
        public ICommandViewModel DelFirmaCommand
        {
            get
            {
                if (_delFirmaCommand == null)
                {
                    _delFirmaCommand = new SimpleCommandViewModel(
                        "Edit",
                        "Editet",
                        DelFirma,
                        CanEdit);
                }
                return _delFirmaCommand;
            }
        }

        public void DelFirma()
        {
            _companyID = 0;
            EingabeKunde = "";
            ColorTransparent();
        }

        public bool CanDelFirma()
        { return true; }

        public void ColorTransparent()
        {
            _brushobj = (Brush)new BrushConverter().ConvertFromString("Transparent");
            OnPropertyChanged("LabelSearchName");
            LabelColor = "Transparent";
        }
        public void ColorGreen()
        {
            _brushobj = (Brush)new BrushConverter().ConvertFromString("Green");
            OnPropertyChanged("LabelSearchName");
            LabelColor = "Green";
            CanSearch();
        }
        public void ColorRed()
        {
            _brushobj = (Brush)new BrushConverter().ConvertFromString("Red");
            OnPropertyChanged("LabelSearchName");
            LabelColor = "Red";
        }

        private static Brush _brushobj;
        public Brush LabelSearchName
        {
            get
            {
                return _brushobj;
            }
        }

        private string _labelColor;
        public string LabelColor
        {
            get
            {
                return _labelColor;
            }

            set
            {
                if (_labelColor != value)
                {
                    _labelColor = value;
                }
            }
        }

        private ICommandViewModel _printInvoice;
        public ICommandViewModel PrintInvoice
        {
            get
            {
                if (_printInvoice == null)
                {
                    _printInvoice = new SimpleCommandViewModel(
                        "Edit",
                        "Editet",
                        PrintInvoiceAction,
                        CanPrintInvoiceButton);
                }
                return _printInvoice;
            }
        }

        public void PrintInvoiceAction()
        {
            InvoiceObject invobj = new InvoiceObject();

            invobj.ID = ID;
            invobj.ErstellungsDatum = DatumErstellung;
            invobj.FaelligkeitsDatum = DatumFaellig;
            invobj.FK_Kontakt = FK_Kontakt;
            invobj.Kommentar = Kommentar;
            invobj.Nachricht = Nachricht;
            invobj.InvoiceLines = invoicelines;


            PdfCreator pdfcre = new PdfCreator();
            pdfcre.WritePDF(invobj);
        }

        public bool CanPrintInvoiceButton()
        { return true; }
    }
}
