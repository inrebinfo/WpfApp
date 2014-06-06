using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class InvoiceViewModel : ViewModel
    {
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
                    OnPropertyChanged("ID");
                }
            }
        }

        private DateTime _erstellungsDatum;
        public DateTime ErstellungsDatum
        {
            get
            {
                return _erstellungsDatum;
            }
            set
            {
                if (_erstellungsDatum != value)
                {
                    _erstellungsDatum = value;
                    OnPropertyChanged("ErstellungsDatum");
                }
            }
        }

        private DateTime _faelligkeitsDatum;
        public DateTime FaelligkeitsDatum
        {
            get
            {
                return _faelligkeitsDatum;
            }
            set
            {
                if (_faelligkeitsDatum != value)
                {
                    _faelligkeitsDatum = value;
                    OnPropertyChanged("FaelligkeitsDatum");
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
                    OnPropertyChanged("Kommentar");
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
                    OnPropertyChanged("Nachricht");
                }
            }
        }

        private string _fk_kontakt;
        public string FK_Kontakt
        {
            get
            {
                return _fk_kontakt;
            }
            set
            {
                if (_fk_kontakt != value)
                {
                    _fk_kontakt = value;
                    OnPropertyChanged("FK_Kontakt");
                }
            }
        }

        private string _summe;
        public string Summe
        {
            get
            {
                return _summe;
            }
            set
            {
                if (_summe != value)
                {
                    _summe = value;
                    OnPropertyChanged("Summe");
                }
            }
        }

        

        private InvoiceObject item;

        public InvoiceViewModel(InvoiceObject item)
        {
            // TODO: Complete member initialization
            this.item = item;

            _id = item.ID;
            _fk_kontakt = item.FK_Kontakt;
            _erstellungsDatum = item.ErstellungsDatum;
            _faelligkeitsDatum = item.FaelligkeitsDatum;
            _kommentar = item.Kommentar;
            _nachricht = item.Nachricht;
            _summe = item.Summe;
            
        }
    }
}
