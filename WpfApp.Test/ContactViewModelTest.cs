using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class ContactViewModelTest
    {
        [TestMethod]
        public void ContactViewModel_IDPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.ID = "1";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.ID, model.ID);
        }

        [TestMethod]
        public void ContactViewModel_TitelPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Titel = "Magister";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Titel, model.Titel);
        }

        [TestMethod]
        public void ContactViewModel_VornamePropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Vorname = "Klaus";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Vorname, model.Vorname);
        }

        [TestMethod]
        public void ContactViewModel_NachnamePropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Nachname = "Gruber";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Nachname, model.Nachname);
        }

        [TestMethod]
        public void ContactViewModel_SuffixPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Suffix = "BSc";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Suffix, model.Suffix);
        }

        [TestMethod]
        public void ContactViewModel_GeburtsdatumPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Geburtsdatum = "19.07.1993";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Geburtsdatum, model.Geburtstag);
        }

        [TestMethod]
        public void ContactViewModel_UIDPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.UID = "19071993";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.UID, model.UID);
        }

        [TestMethod]
        public void ContactViewModel_StrassePropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Strasse = "Poststrasse 26";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Strasse, model.Strasse);
        }

        [TestMethod]
        public void ContactViewModel_PLZPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.PLZ = "2316";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.PLZ, model.PLZ);
        }

        [TestMethod]
        public void ContactViewModel_OrtPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.Ort = "Blütenhausen";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.Ort, model.Ort);
        }

        [TestMethod]
        public void ContactViewModel_FKKontaktPropertyCorrectParsedTest()
        {
            ContactObject obj = new ContactObject();

            obj.FK_Kontakt = "2";

            ContactViewModel model = new ContactViewModel(obj);

            Assert.AreEqual(obj.FK_Kontakt, model.FK_Kontakt);
        }
    }
}
