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
        private ContactObject item;

        public ContactViewModel(ContactObject item)
        {
            // TODO: Complete member initialization
            this.item = item;

            _firma = item.Firmenname;
            _vorname = item.Vorname;
            _nachname = item.Nachname;
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
    }
}
