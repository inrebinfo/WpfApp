using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class InvoiceLineViewModel : ViewModel
    {
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
                    OnPropertyChanged("Menge");
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
                    OnPropertyChanged("Stkpreis");
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
                    OnPropertyChanged("UST");
                }
            }
        }

        private string _fkrechnung;
        public string FK_Rechnung
        {
            get
            {
                return _fkrechnung;
            }
            set
            {
                if (_fkrechnung != value)
                {
                    _fkrechnung = value;
                    OnPropertyChanged("FK_Rechnung");
                }
            }
        }

        private InvoiceLineObject item;

        public InvoiceLineViewModel(InvoiceLineObject item)
        {
            // TODO: Complete member initialization
            this.item = item;

            _menge = item.Menge;
            _fkrechnung = item.FK_Rechnung;
            _stkpreis = item.Stkpreis;
            _ust = item.UST;
            
        }
    }
}
