using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels.Samples
{
    public class MVVMViewModel : ViewModel
    {
        #region Person
        private string _Vorname;
        public string Vorname
        {
            get
            {
                return _Vorname;
            }
            set
            {
                if (_Vorname != value)
                {
                    _Vorname = value;
                    OnPropertyChanged("Vorname");
                    NotifyStateChanged();
                }
            }
        }

        private string _Nachname;
        public string Nachname
        {
            get
            {
                return _Nachname;
            }
            set
            {
                if (_Nachname != value)
                {
                    _Nachname = value;
                    OnPropertyChanged("Nachname");
                    NotifyStateChanged();
                }
            }
        }
        #endregion

        #region Firma
        private string _Firmenname;
        public string Firmenname
        {
            get
            {
                return _Firmenname;
            }
            set
            {
                if (_Firmenname != value)
                {
                    _Firmenname = value;
                    OnPropertyChanged("Firmenname");
                    NotifyStateChanged();
                }
            }
        }
        private string _UID;
        public string UID
        {
            get
            {
                return _UID;
            }
            set
            {
                if (_UID != value)
                {
                    _UID = value;
                    OnPropertyChanged("UID");
                }
            }
        }
        #endregion

        #region View
        public bool? IsFirma
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Nachname) && string.IsNullOrWhiteSpace(Vorname) && string.IsNullOrWhiteSpace(Firmenname)) return null;
                return !string.IsNullOrWhiteSpace(Firmenname);
            }
        }

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

        private void NotifyStateChanged()
        {
            OnPropertyChanged("IsFirma");
            OnPropertyChanged("CanEditPerson");
            OnPropertyChanged("CanEditFirma");
        }
        #endregion
    }
}
