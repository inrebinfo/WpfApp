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

    }
}
