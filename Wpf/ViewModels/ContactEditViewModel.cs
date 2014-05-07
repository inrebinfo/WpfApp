﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wpf.ViewModels
{
    public class ContactEditViewModel : EditViewModel
    {

        private int _companyID;
        public bool _isEdit { get; set; }

        public override void Edit()
        {
            MessageBox.Show("edit");
        }

        public override bool CanEdit()
        {
            return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);
        }

        public override void Search()
        {
            //firmensuche
            Proxy prox = new Proxy();
            prox.SearchCompany(EingabeFirmaKunde);
            var result = prox.getList;

            this.Items.Clear();

            if (result.Count == 1)
            {
                _companyID = Convert.ToInt32(result[0].ID);
                MessageBox.Show("genau 1");
            }
            else if (result.Count > 1)
            {
                CompanySearch wnd = new CompanySearch(result, this);
                wnd.Show();
                MessageBox.Show("mehrere");
            }
            else
            {
                MessageBox.Show("keine");
            }

            /*foreach (var item in result)
            {
                this.Items.Add(new ContactViewModel(item));
            }*/
        }

        public override bool CanSearch()
        {
            /*return !string.IsNullOrWhiteSpace(EingabeVorname)
                || !string.IsNullOrWhiteSpace(EingabeNachname)
                || !string.IsNullOrWhiteSpace(EingabeFirma);*/
            return true;
        }

        public override GridDisplayConfiguration DisplayedColumns
        {
            get { return null; }
        }

        public void NotifyStateChanged()
        {
            OnPropertyChanged("EingabeFirmaKunde");
        }

        public void ReceiveCompany(ContactViewModel model)
        {
            EingabeFirmaKunde = model.Firma;
            _companyID = Convert.ToInt32(model.ID);
        }

        #region input properties
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

        private string _eingabeFirmaKunde;
        public string EingabeFirmaKunde
        {
            get
            {
                return _eingabeFirmaKunde;
            }
            set
            {
                if (_eingabeFirmaKunde != value)
                {
                    _eingabeFirmaKunde = value;
                    EditCommand.OnCanExecuteChanged();
                    NotifyStateChanged();
                    OnPropertyChanged("EingabeFirmaKunde");
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

        #endregion
    }
}
