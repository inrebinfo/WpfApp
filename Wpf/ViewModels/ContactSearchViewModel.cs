using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wpf.ViewModels
{
    public class ContactSearchViewModel : SearchViewModel
    {

        public override void Search()
        {
            Proxy prox = new Proxy();
            var result = prox.getList;

            this.Items.Clear();

            foreach (var item in result)
            {
                this.Items.Add(new ContactViewModel(item));
            }
        }

        public override bool CanSearch()
        {
            return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { throw new NotImplementedException(); }
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
                    SearchCommand.OnCanExecuteChanged();
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
                    SearchCommand.OnCanExecuteChanged();
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
                    SearchCommand.OnCanExecuteChanged();
                    OnPropertyChanged("EingabeFirma");
                }
            }
        }

        
    }
}
