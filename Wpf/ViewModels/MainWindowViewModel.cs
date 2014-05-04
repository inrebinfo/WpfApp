using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Wpf.ViewModels.Samples;
using System.Collections.ObjectModel;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        private InvoiceSearchViewModel _invoicesearchviewmodel;
        public InvoiceSearchViewModel InvoiceSearchViewModel
        {
            get
            {
                if (_invoicesearchviewmodel == null)
                {
                    _invoicesearchviewmodel = new InvoiceSearchViewModel();
                }
                return _invoicesearchviewmodel;
            }
        }

        private ContactSearchViewModel _contactsearchviewmodel;
        public ContactSearchViewModel ContactSearchViewModel
        {
            get
            {
                if (_contactsearchviewmodel == null)
                {
                    _contactsearchviewmodel = new ContactSearchViewModel();
                }
                return _contactsearchviewmodel;
            }
        }
    }
}
