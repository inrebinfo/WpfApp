using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wpf
{
    [Serializable()]
    public class InvoiceLineObject : System.ComponentModel.INotifyPropertyChanged
    {
        [XmlElement(ElementName = "Menge")]
        public string Menge { get; set; }
        [XmlElement(ElementName = "Stkpreis")]
        public string Stkpreis { get; set; }
        [XmlElement(ElementName = "UST")]
        public string UST { get; set; }
        [XmlElement(ElementName = "FK_Rechnung")]
        public string FK_Rechnung { get; set; }

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
