using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class ContactViewModel : ViewModel
    {
        private string _vorname;
        public string Vorname
        {
            get
            {
                return _vorname;
            }
            set
            {
                if (_vorname != value)
                {
                    _vorname = value;
                    OnPropertyChanged("Vorname");
                }
            }
        }

        private string _nachname;
        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                if (_nachname != value)
                {
                    _nachname= value;
                    OnPropertyChanged("Nachname");
                }
            }
        }

        private string _firma;
        public string Firma
        {
            get
            {
                return _firma;
            }
            set
            {
                if (_firma != value)
                {
                    _firma = value;
                    OnPropertyChanged("Firma");
                }
            }
        }

        private string _titel;
        public string Titel
        {
            get
            {
                return _titel;
            }
            set
            {
                if (_titel != value)
                {
                    _titel = value;
                    OnPropertyChanged("Titel");
                }
            }
        }

        private string _suffix;
        public string Suffix
        {
            get
            {
                return _suffix;
            }
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    OnPropertyChanged("Suffix");
                }
            }
        }

        private string _geburtstag;
        public string Geburtstag
        {
            get
            {
                return _geburtstag;
            }
            set
            {
                if (_geburtstag != value)
                {
                    _geburtstag = value;
                    OnPropertyChanged("Geburtstag");
                }
            }
        }

        private string _uid;
        public string UID
        {
            get
            {
                return _uid;
            }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                    OnPropertyChanged("UID");
                }
            }
        }

        private string _strasse;
        public string Strasse
        {
            get
            {
                return _strasse;
            }
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                    OnPropertyChanged("Strasse");
                }
            }
        }

        private string _plz;
        public string PLZ
        {
            get
            {
                return _plz;
            }
            set
            {
                if (_plz != value)
                {
                    _plz = value;
                    OnPropertyChanged("PLZ");
                }
            }
        }

        private string _ort;
        public string Ort
        {
            get
            {
                return _ort;
            }
            set
            {
                if (_ort != value)
                {
                    _ort = value;
                    OnPropertyChanged("Ort");
                }
            }
        }

        

        private ContactObject item;

        public ContactViewModel(ContactObject item)
        {
            // TODO: Complete member initialization
            this.item = item;

            _firma = item.Firmenname;
            _vorname = item.Vorname;
            _nachname = item.Nachname;
            _titel = item.Titel;
            _suffix = item.Suffix;
            _geburtstag = item.Geburtsdatum;
            _uid = item.UID;
            _strasse = item.Strasse;
            _plz = item.PLZ;
            _ort = item.Ort;
        }

        /// <summary>
        /// zum speichern ist noch nicht fertig implementiert
        /// </summary>
        /// <param name="item"></param>
        public void ApplyChanges()
        {
            item.Firmenname = _firma;
            item.Vorname = _vorname;
            item.Nachname = _nachname;

        }

    }
}
