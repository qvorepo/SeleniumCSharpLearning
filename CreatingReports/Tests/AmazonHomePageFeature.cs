using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("AmazonHomePageFeature")]
 
    public class AmazonHomePageFeature : BaseTest
    {
        [TestMethod]
        [Description("Checks to make sure that the Amazon homepage is loaded successfully.")]
        [TestProperty("Author", "Quang Vo")]
        public void TCID_01_AmazonHomepageTest()
        {
            var homepage = new AmazonHomePage(Driver);
            homepage.GoTo();
            Assert.IsTrue(homepage.IsLoaded, "Amazon homepage did not open sucessfully.");
        }
    }
}
