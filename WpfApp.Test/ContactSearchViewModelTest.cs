using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wpf;
using Wpf.ViewModels;

namespace WpfApp.Test
{
    [TestClass]
    public class ContactSearchViewModelTest
    {
        [TestMethod]
        public void ContactSearchViewModel_CanSearchReturnsTrue()
        {
            ContactSearchViewModel model = new ContactSearchViewModel();

            //string toCheck = "Schinkhofen";
            bool toCheck = true;
            model.SearchText = "Klaus";

            Assert.AreEqual(toCheck, model.CanSearch());
        }
    }
}
