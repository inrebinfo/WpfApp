using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class InvoiceViewModelTest
    {
        [TestMethod]
        public void InvoiceViewModel_IDPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.ID = "1";

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.ID, model.ID);
        }

        [TestMethod]
        public void InvoiceViewModel_ErstellungsdatumPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.ErstellungsDatum = DateTime.Now;

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.ErstellungsDatum, model.ErstellungsDatum);
        }

        [TestMethod]
        public void InvoiceViewModel_FaelligkeitsdatumPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.FaelligkeitsDatum = DateTime.Now;

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.FaelligkeitsDatum, model.FaelligkeitsDatum);
        }

        [TestMethod]
        public void InvoiceViewModel_KommentarPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.Kommentar = "Kommentar";

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.Kommentar, model.Kommentar);
        }

        [TestMethod]
        public void InvoiceViewModel_NachrichtPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.Nachricht = "Nachricht";

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.Nachricht, model.Nachricht);
        }

        [TestMethod]
        public void InvoiceViewModel_FKKontaktPropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.FK_Kontakt = "1";

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.FK_Kontakt, model.FK_Kontakt);
        }

        [TestMethod]
        public void InvoiceViewModel_SummePropertyCorrectParsedTest()
        {
            InvoiceObject obj = new InvoiceObject();

            obj.Summe = "38.98";

            InvoiceViewModel model = new InvoiceViewModel(obj);

            Assert.AreEqual(obj.Summe, model.Summe);
        }
    }
}
