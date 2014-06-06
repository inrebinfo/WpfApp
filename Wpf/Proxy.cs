using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Wpf.ViewModels;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml;


namespace Wpf
{
    public class Proxy
    {
        public List<ContactObject> _contactList = new List<ContactObject>();
        public ContactObject contact = new ContactObject();

        public List<InvoiceObject> _invoiceList = new List<InvoiceObject>();

        public List<InvoiceLineObject> _invoiceLinesList = new List<InvoiceLineObject>();



        public Proxy()
        {

        }

        public void SearchContacts(string searchParam)
        {
            string postData = "mode=search&contact=" + searchParam;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);


            WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = req.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            var serializer = new XmlSerializer(typeof(List<ContactObject>), new XmlRootAttribute("ArrayOfContactObject"));
            using (var stringReader = new StringReader(responseFromServer))
            using (var reader2 = XmlReader.Create(stringReader))
            {
                var result = (List<ContactObject>)serializer.Deserialize(reader2);
                _contactList = result;
            }

        }

        public void SearchCompany(string searchParam)
        {
            string postData = "mode=search&company=" + searchParam;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);


            WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = req.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            var serializer = new XmlSerializer(typeof(List<ContactObject>), new XmlRootAttribute("ArrayOfContactObject"));
            using (var stringReader = new StringReader(responseFromServer))
            using (var reader2 = XmlReader.Create(stringReader))
            {
                var result = (List<ContactObject>)serializer.Deserialize(reader2);
                _contactList = result;
            }

        }

        public void SaveContact(ContactObject contact, bool edit)
        {
            if (edit == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContactObject));

                byte[] respBytes;

                StringWriter textWriter = new StringWriter();

                MemoryStream memstream = new MemoryStream();
                serializer.Serialize(textWriter, contact);

                string rsp = textWriter.ToString();

                string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(rsp));

                string count = base64.Count(x => x == '=').ToString();

                string postData = "mode=update&toadd="+count+"&contact=" + base64;

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
                req.Method = "POST";

                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = byteArray.Length;

                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ContactObject));

                byte[] respBytes;

                StringWriter textWriter = new StringWriter();

                MemoryStream memstream = new MemoryStream();
                serializer.Serialize(textWriter, contact);

                string rsp = textWriter.ToString();

                string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(rsp));

                string count = base64.Count(x => x == '=').ToString();

                string postData = "mode=insert&toadd=" + count + "&contact=" + base64;

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
                req.Method = "POST";

                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = byteArray.Length;

                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
        }

        public void SearchInvoice(string searchParam)
        {
            string postData = "mode=search&invoice=" + searchParam;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);


            WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = req.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            var serializer = new XmlSerializer(typeof(List<InvoiceObject>), new XmlRootAttribute("ArrayOfInvoiceObject"));
            using (var stringReader = new StringReader(responseFromServer))
            using (var reader2 = XmlReader.Create(stringReader))
            {
                var result = (List<InvoiceObject>)serializer.Deserialize(reader2);
                _invoiceList = result;
            }

        }

        public void SearchInvoiceLines(string searchParam)
        {
            string postData = "mode=search&invoicelines=" + searchParam;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);


            WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = req.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            var serializer = new XmlSerializer(typeof(List<InvoiceLineObject>), new XmlRootAttribute("ArrayOfInvoiceLineObject"));
            using (var stringReader = new StringReader(responseFromServer))
            using (var reader2 = XmlReader.Create(stringReader))
            {
                var result = (List<InvoiceLineObject>)serializer.Deserialize(reader2);
                _invoiceLinesList = result;
            }

        }

        public void SaveContact(InvoiceObject invoice)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(InvoiceObject));

            byte[] respBytes;

            StringWriter textWriter = new StringWriter();

            MemoryStream memstream = new MemoryStream();
            serializer.Serialize(textWriter, invoice);

            string rsp = textWriter.ToString();

            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(rsp));

            string count = base64.Count(x => x == '=').ToString();

            string postData = "mode=insert&toadd=" + count + "&invoice=" + base64;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            WebRequest req = WebRequest.Create("http://localhost:8080/MicroERP.html");
            req.Method = "POST";

            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = byteArray.Length;

            Stream dataStream = req.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public ContactObject getContact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        public List<ContactObject> getList
        {
            get
            {
                return _contactList;
            }
            set
            {
                _contactList = value;
            }
        }

        public List<InvoiceObject> getInvoiceList
        {
            get
            {
                return _invoiceList;
            }
            set
            {
                _invoiceList = value;
            }
        }

        public List<InvoiceLineObject> getInvoiceLinesList
        {
            get
            {
                return _invoiceLinesList;
            }
            set
            {
                _invoiceLinesList = value;
            }
        }
    }
}
