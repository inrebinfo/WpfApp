using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wpf
{
    [Serializable()]
    public class InvoiceObject : System.ComponentModel.INotifyPropertyChanged
    {
        //Person
        [XmlElement(ElementName = "ID")]
        public string ID { get; set; }
        [XmlElement(ElementName = "ErstellungsDatum")]
        public DateTime ErstellungsDatum { get; set; }
        [XmlElement(ElementName = "FaelligkeitsDatum")]
        public DateTime FaelligkeitsDatum { get; set; }
        [XmlElement(ElementName = "Kommentar")]
        public string Kommentar { get; set; }
        [XmlElement(ElementName = "Nachricht")]
        public string Nachricht { get; set; }
        [XmlElement(ElementName = "FK_Kontakt")]
        public string FK_Kontakt { get; set; }
        [XmlElement(ElementName = "Summe")]
        public string Summe { get; set; }
        [XmlElement(ElementName = "InvoiceLines")]
        public List<InvoiceLineObject> InvoiceLines { get; set; }

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
