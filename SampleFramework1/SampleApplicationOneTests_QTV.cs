using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne22")]
    public class SampleApplicationOneTests_QTV
    {
        private IWebDriver Driver { get; set; }
        internal TestUser TheTestUser { get; private set; }
        internal SampleApplicationPage_QTV SampleAppPage { get; private set; }
        //internal TestUser PrimaryContactUser { get; private set; }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            SampleAppPage = new SampleApplicationPage_QTV(Driver);

            TheTestUser = new TestUser();
            TheTestUser.GenderType = Gender.Female;
            TheTestUser.FirstName = "Quang";
            TheTestUser.LastName = "Vo";


        }

        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        private static void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }


        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            //SetGenderTypes( Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutFormAndSubmit(TheTestUser);
            var ultimateQAHomePage = SampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }




    }
}
