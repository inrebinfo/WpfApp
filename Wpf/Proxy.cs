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



        public Proxy()
        {

        }

        public void SearchContacts(string searchParam)
        {
            string postData = "mode=search&searchstring=" + searchParam;
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
    }
}
