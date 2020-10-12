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
    [TestCategory("SignIn_QTV")]
    [TestCategory("SampleApp2_QTV")]
    class SignInFunctionality_QTV : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "QuangVo")]
        public void TCID05()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsLoaded, "Homepage failed to open successfully.");

            var signInPage = homePage.Header.ClickSignInButton();
            Assert.IsTrue(signInPage.IsLoaded, "SignIn page failed to open successfully.");

        }
    }
}
