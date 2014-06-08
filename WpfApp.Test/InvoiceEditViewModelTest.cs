using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class InvoiceEditViewModelTest
    {
        [TestMethod]
        public void InvoiceEditViewModel_IDPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "1";
            model.ID = "1";

            Assert.AreEqual(toCheck, model.ID);
        }

        [TestMethod]
        public void InvoiceEditViewModel_KundePropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "Firmenname";
            model.EingabeKunde = "Firmenname";

            Assert.AreEqual(toCheck, model.EingabeKunde);
        }

        [TestMethod]
        public void InvoiceEditViewModel_ErstellungsdatumPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            DateTime toCheck = DateTime.Now;
            model.DatumErstellung = DateTime.Now;

            Assert.AreEqual(toCheck, model.DatumErstellung);
        }

        [TestMethod]
        public void InvoiceEditViewModel_FaelligkeitsdatumPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            DateTime toCheck = DateTime.Now;
            model.DatumFaellig = DateTime.Now;

            Assert.AreEqual(toCheck, model.DatumFaellig);
        }

        [TestMethod]
        public void InvoiceEditViewModel_NachrichtPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "Eine Testnachricht für die Rechnung. Einfach ein längerer String.";
            model.Nachricht = "Eine Testnachricht für die Rechnung. Einfach ein längerer String.";

            Assert.AreEqual(toCheck, model.Nachricht);
        }

        [TestMethod]
        public void InvoiceEditViewModel_KommentarPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "Ein kurzer Kommentar.";
            model.Kommentar = "Ein kurzer Kommentar.";

            Assert.AreEqual(toCheck, model.Kommentar);
        }

        [TestMethod]
        public void InvoiceEditViewModel_FKKontaktPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "2";
            model.FK_Kontakt = "2";

            Assert.AreEqual(toCheck, model.FK_Kontakt);
        }

        [TestMethod]
        public void InvoiceEditViewModel_MengePropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "2";
            model.Menge = "2";

            Assert.AreEqual(toCheck, model.Menge);
        }

        [TestMethod]
        public void InvoiceEditViewModel_StkpreisPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "15.99";
            model.Stkpreis = "15.99";

            Assert.AreEqual(toCheck, model.Stkpreis);
        }

        [TestMethod]
        public void InvoiceEditViewModel_USTPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "2";
            model.UST = "2";

            Assert.AreEqual(toCheck, model.UST);
        }

        [TestMethod]
        public void InvoiceEditViewModel_NettogesamtPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "35,98";
            model.Nettogesamt = "35,98";

            Assert.AreEqual(toCheck, model.Nettogesamt);
        }

        [TestMethod]
        public void InvoiceEditViewModel_BruttogesamtPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "43,17";
            model.Bruttogesamt = "43,17";

            Assert.AreEqual(toCheck, model.Bruttogesamt);
        }

        [TestMethod]
        public void InvoiceEditViewModel_EingabeMengePropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "12";
            model.EingabeMenge = "12";

            Assert.AreEqual(toCheck, model.EingabeMenge);
        }

        [TestMethod]
        public void InvoiceEditViewModel_EingabeStkpreisPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "11.69";
            model.EingabeStkpreis = "11.69";

            Assert.AreEqual(toCheck, model.EingabeStkpreis);
        }

        [TestMethod]
        public void InvoiceEditViewModel_EingabeUSTPropertyCorrectParsedTest()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            string toCheck = "20";
            model.EingabeUST = "20";

            Assert.AreEqual(toCheck, model.EingabeUST);
        }

        [TestMethod]
        public void InvoiceEditViewModel_ColorTransparent()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            model.ColorTransparent();

            Assert.AreEqual(model.LabelColor, "Transparent");
        }

        [TestMethod]
        public void InvoiceEditViewModel_ColorRed()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            model.ColorRed();

            Assert.AreEqual(model.LabelColor, "Red");
        }

        [TestMethod]
        public void InvoiceEditViewModel_ColorGreen()
        {
            InvoiceEditViewModel model = new InvoiceEditViewModel();

            model.ColorGreen();

            Assert.AreEqual(model.LabelColor, "Green");
        }
    }
}
