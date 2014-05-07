using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class InvoiceSearchViewModel : SearchViewModel
    {
        public override void Search()
        {
            throw new NotImplementedException();
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { throw new NotImplementedException(); }
        }

        public override bool CanSearch()
        {
            throw new NotImplementedException();
        }

        public override void NewContactWindow()
        {
        }

        public override bool CanNewContactWindow()
        {
            return true;
        }
    }
}
