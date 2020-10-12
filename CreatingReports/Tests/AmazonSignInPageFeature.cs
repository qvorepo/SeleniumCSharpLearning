using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CreatingReports.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreatingReports.Tests
{
    [TestClass]
    [TestCategory("AmazonSignInPageFeature")]
 
    public class AmazonSignInPageFeature : BaseTest
    {
        [TestMethod]
        [Description("Checks to make sure that the Amazon Signin page is loaded successfully.")]
        [TestProperty("Author", "Quang Vo")]

        
        public void TCID_02_AmazonSignInPageTest()
        {
            var homePage = new AmazonHomePage(Driver);
            
            
            homePage.GoTo();
            Assert.IsTrue(homePage.IsLoaded, "Amazon homepage did not open sucessfully.");

            AmazonSignInPage signInPage;
            signInPage=homePage.ClickHelloSignInBox();
            Assert.IsTrue(signInPage.IsLoaded, "Amazon Sign in page did not open sucessfully.");

            signInPage.LogIn(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"]);
            var isAuthenticated = signInPage.AuthenicatedRequiredHeading.Displayed;
            Assert.IsTrue(isAuthenticated, "The Authentication page is not displayed"); 
            
        }
    }
}
