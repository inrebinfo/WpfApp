using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class ContactEditViewModelTest
    {
        [TestMethod]
        public void ContactEditViewModel_IDPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "1";
            model.ID = "1";

            Assert.AreEqual(toCheck, model.ID);
        }

        [TestMethod]
        public void ContactEditViewModel_FirstnamePropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Kurt";
            model.EingabeVorname = "Kurt";

            Assert.AreEqual(toCheck, model.EingabeVorname);
        }

        [TestMethod]
        public void ContactEditViewModel_LastnamePropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Müller";
            model.EingabeNachname = "Müller";

            Assert.AreEqual(toCheck, model.EingabeNachname);
        }

        [TestMethod]
        public void ContactEditViewModel_FirmaPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Firma";
            model.EingabeFirma = "Firma";

            Assert.AreEqual(toCheck, model.EingabeFirma);
        }

        [TestMethod]
        public void ContactEditViewModel_FirmaKundePropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "FirmaKunde";
            model.EingabeFirmaKunde = "FirmaKunde";

            Assert.AreEqual(toCheck, model.EingabeFirmaKunde);
        }

        [TestMethod]
        public void ContactEditViewModel_TitelPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Magister";
            model.EingabeTitel = "Magister";

            Assert.AreEqual(toCheck, model.EingabeTitel);
        }

        [TestMethod]
        public void ContactEditViewModel_SuffixPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "BSc";
            model.EingabeSuffix = "BSc";

            Assert.AreEqual(toCheck, model.EingabeSuffix);
        }

        [TestMethod]
        public void ContactEditViewModel_GeburtstagPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "19.07.1993";
            model.EingabeGeburtstag = "19.07.1993";

            Assert.AreEqual(toCheck, model.EingabeGeburtstag);
        }

        [TestMethod]
        public void ContactEditViewModel_UIDPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "40861739";
            model.EingabeUID = "40861739";

            Assert.AreEqual(toCheck, model.EingabeUID);
        }

        [TestMethod]
        public void ContactEditViewModel_StrassePropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Wiener Straße 21";
            model.EingabeStrasse = "Wiener Straße 21";

            Assert.AreEqual(toCheck, model.EingabeStrasse);
        }

        [TestMethod]
        public void ContactEditViewModel_PLZPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "1120";
            model.EingabePLZ = "1120";

            Assert.AreEqual(toCheck, model.EingabePLZ);
        }

        [TestMethod]
        public void ContactEditViewModel_OrtPropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Schinkhofen";
            model.EingabeOrt = "Schinkhofen";

            Assert.AreEqual(toCheck, model.EingabeOrt);
        }

        [TestMethod]
        public void ContactEditViewModel_CanEditReturnsTrueWithFirstAndLastName()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            //string toCheck = "Schinkhofen";
            bool toCheck = true;
            model.EingabeVorname = "Klaus";
            model.EingabeNachname = "Gruber";

            Assert.AreEqual(toCheck, model.CanEdit());
        }

        [TestMethod]
        public void ContactEditViewModel_CanEditReturnsTrueWithCompanyname()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            //string toCheck = "Schinkhofen";
            bool toCheck = true;
            model.EingabeFirma = "Arbeitsfirma & Co. KG";

            Assert.AreEqual(toCheck, model.CanEdit());
        }

        [TestMethod]
        public void ContactEditViewModel_ReceiveCompanyIDParsed()
        {
            ContactEditViewModel model = new ContactEditViewModel();
            ContactObject obj = new ContactObject();
            obj.ID = "5";
            ContactViewModel model2 = new ContactViewModel(obj);

            model.ReceiveCompany(model2);

            Assert.AreEqual(Convert.ToInt32(obj.ID), model._companyID);
        }

        [TestMethod]
        public void ContactEditViewModel_ReceiveCompanyNameParsed()
        {
            ContactEditViewModel model = new ContactEditViewModel();
            ContactObject obj = new ContactObject();
            obj.Firmenname = "Lug und Trug GMbH";
            ContactViewModel model2 = new ContactViewModel(obj);

            model.ReceiveCompany(model2);

            Assert.AreEqual(obj.Firmenname, model.EingabeFirmaKunde);
        }

        [TestMethod]
        public void ContactEditViewModel_DelFirmaSuccessful()
        {
            ContactEditViewModel model = new ContactEditViewModel();
            model.ID = "5";
            model.EingabeFirmaKunde = "Lug und Trug GMbH";

            model.DelFirma();

            Assert.AreEqual(0, model._companyID);
            Assert.AreEqual("", model.EingabeFirmaKunde);
        }

        [TestMethod]
        public void ContactEditViewModel_ColorTransparent()
        {
            ContactEditViewModel model = new ContactEditViewModel();
            
            model.ColorTransparent();

            Assert.AreEqual(model.LabelColor, "Transparent");
        }

        [TestMethod]
        public void ContactEditViewModel_ColorRed()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            model.ColorRed();

            Assert.AreEqual(model.LabelColor, "Red");
        }

        [TestMethod]
        public void ContactEditViewModel_ColorGreen()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            model.ColorGreen();

            Assert.AreEqual(model.LabelColor, "Green");
        }
    }
}
