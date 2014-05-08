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
        public void FirstnamePropertyCorrectParsedTest()
        {
            ContactEditViewModel model = new ContactEditViewModel();

            string toCheck = "Kurt";
            model.EingabeVorname = "Kurt";

            Assert.AreEqual(toCheck, model.EingabeVorname);
        }
    }
}
