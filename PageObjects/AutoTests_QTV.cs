using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
//using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace PageObjects
{
    [TestClass]
    [TestCategory("PageObject Tests")]
    public class AutoTests_QTV
    {
        private IWebDriver _driver;
        [TestInitialize]
        public void Setup()
        {
            _driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }
        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
        [TestMethod]
        public void Test()
        {
            _driver.Navigate().GoToUrl("http://ultimateqa.com");
            _driver.FindElement(By.Id("et_search_icon")).Click();


            //Assert.AreEqual(1, theShoppingCart.ItemsInCart(), "we added only 1 item to the cart");
        }

       
    }
}
