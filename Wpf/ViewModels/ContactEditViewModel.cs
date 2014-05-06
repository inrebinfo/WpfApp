using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class ContactEditViewModel : EditViewModel
    {

        public override void Edit()
        {
            
        }

        public override bool CanEdit()
        {
            return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeFirma");
                }
            }
        }

        private string _eingabeTitel;
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
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
                    EditCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeOrt");
                }
            }
        }

    }
}
