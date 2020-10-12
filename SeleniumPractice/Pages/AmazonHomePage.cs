using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumPractice.Pages
{
    internal class AmazonHomePage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        //Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more
        public AmazonHomePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement HelloSignInBox => Driver.FindElement(By.XPath("//span[contains(text(), 'Hello, Sign in')]"));
        
        //public IWebElement SignInButton => Driver.FindElement(By.XPath("//span[contains(@class,'nav-action-inner')]  [contains(text(),'Sign in')]"));


        internal void GoTo()
        {
            var url = "http://amazon.com";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"In a browser, go to url=>{url}");
        }

        public bool IsLoaded
        {

            get
            {
                //var isLoaded = Driver.Url.Contains("http://automationpractice.com/index.php");
                var isLoaded = Driver.Title.Contains("Amazon.com: Online Shopping for Electronics, Apparel, Computers, Books, DVDs & more");
                Reporter.LogTestStepForBugLogger(Status.Info, "Validate whether the Home Page loaded successfully.");
                _logger.Trace($"Home page is loaded=>{isLoaded}");
                return isLoaded;
            }
        }

        internal AmazonSignInPage ClickHelloSignInBox()
        { 
            HelloSignInBox.Click();
            return new AmazonSignInPage(Driver);
        }
    }
}
