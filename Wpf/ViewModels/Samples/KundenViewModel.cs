using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Wpf.ViewModels;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Windows;

namespace Wpf.ViewModels.Samples
{


    public class KundenViewModel : ViewModel
    {

        public ObservableCollection<ContactObject> _Contacts = new ObservableCollection<ContactObject>();


        public KundenViewModel()
        {
            Proxy prox = new Proxy();
            List<ContactObject> oldcontacts = new List<ContactObject>();
            oldcontacts = prox.getList;

            foreach (ContactObject var in oldcontacts)
            {
                _Contacts.Add(var);
               // MessageBox.Show(_Contacts.ToString());
            }
        }

        public ObservableCollection<ContactObject> Contacts
        {
            get { return _Contacts; }
            set
            {
                _Contacts = value;
                OnPropertyChanged("_Contacts");
            }
        }
    }
}
