using System;
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
        private Window _wnd;

        

        public override void Edit()
        {
            //MessageBox.Show("edit");

            ContactObject contactToSave = new ContactObject();

            contactToSave.ID = ID;
            contactToSave.Vorname = EingabeVorname;
            contactToSave.Nachname = EingabeNachname;
            contactToSave.Titel = EingabeTitel;
            contactToSave.Suffix = EingabeSuffix;
            contactToSave.Strasse = EingabeStrasse;
            contactToSave.PLZ = EingabePLZ;
            contactToSave.Ort = EingabeOrt;
            contactToSave.Firmenname = EingabeFirma;
            contactToSave.UID = EingabeUID;
            contactToSave.FK_Kontakt = _companyID.ToString();

            Proxy prox = new Proxy();
            prox.SaveContact(contactToSave, _isEdit);

            //_wnd.Close();
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
                EingabeFirmaKunde = result[0].Firmenname;
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
            //OnPropertyChanged("EingabeFirmaKunde");
            OnPropertyChanged("IsFirma");
            OnPropertyChanged("CanEditFirma");
            OnPropertyChanged("CanEditPerson");
        }

        public void ReceiveCompany(ContactViewModel model)
        {
            EingabeFirmaKunde = model.Firma;
            _companyID = Convert.ToInt32(model.ID);
        }

        // firma (Selbst) firmenzuweisung richtig setzen/filtern
        // deaktivieren properties

        public bool? IsFirma
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EingabeNachname) && string.IsNullOrWhiteSpace(EingabeVorname) && string.IsNullOrWhiteSpace(EingabeFirma))
                    return null;

                return !string.IsNullOrWhiteSpace(EingabeFirma);
            }
        }

        /// <summary>
        /// Enable or Disable Groupbox
        /// </summary>
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

        #region input properties

        private string _id;
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    EditCommand.OnCanExecuteChanged();
                    OnPropertyChanged("ID");
                    NotifyStateChanged();
                }
            }
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
                    OnPropertyChanged("EingabeVorname");
                    NotifyStateChanged();
                    EditCommand.OnCanExecuteChanged();
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
                    OnPropertyChanged("EingabeNachname");
                    NotifyStateChanged();
                    EditCommand.OnCanExecuteChanged();
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
                    OnPropertyChanged("EingabeFirma");
                    NotifyStateChanged();
                    EditCommand.OnCanExecuteChanged();
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
                    OnPropertyChanged("EingabeFirmaKunde");
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
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
                    NotifyStateChanged();
                }
            }
        }

        #endregion
    }
}
