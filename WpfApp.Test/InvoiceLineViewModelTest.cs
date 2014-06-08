using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class InvoiceLineViewModelTest
    {
        [TestMethod]
        public void InvoiceLineViewModel_MengePropertyCorrectParsedTest()
        {
            InvoiceLineObject obj = new InvoiceLineObject();

            obj.Menge = "6";

            InvoiceLineViewModel model = new InvoiceLineViewModel(obj);

            Assert.AreEqual(obj.Menge, model.Menge);
        }

        [TestMethod]
        public void InvoiceLineViewModel_FKRechnungPropertyCorrectParsedTest()
        {
            InvoiceLineObject obj = new InvoiceLineObject();

            obj.FK_Rechnung = "2";

            InvoiceLineViewModel model = new InvoiceLineViewModel(obj);

            Assert.AreEqual(obj.FK_Rechnung, model.FK_Rechnung);
        }

        [TestMethod]
        public void InvoiceLineViewModel_StkpreisPropertyCorrectParsedTest()
        {
            InvoiceLineObject obj = new InvoiceLineObject();

            obj.Stkpreis = "14.89";

            InvoiceLineViewModel model = new InvoiceLineViewModel(obj);

            Assert.AreEqual(obj.Stkpreis, model.Stkpreis);
        }

        [TestMethod]
        public void InvoiceLineViewModel_USTPropertyCorrectParsedTest()
        {
            InvoiceLineObject obj = new InvoiceLineObject();

            obj.UST = "20";

            InvoiceLineViewModel model = new InvoiceLineViewModel(obj);

            Assert.AreEqual(obj.UST, model.UST);
        }
    }
}
