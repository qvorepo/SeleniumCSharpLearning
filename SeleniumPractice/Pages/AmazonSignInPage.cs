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
    internal class AmazonSignInPage : BaseApplicationPage
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public AmazonSignInPage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement EmailTextField => Driver.FindElement(By.Id("ap_email"));
        public IWebElement ContinueBtn => Driver.FindElement(By.Id("continue"));
        public IWebElement PasswordTextField => Driver.FindElement(By.Id("ap_password"));
        public IWebElement SignInSubmitBtn => Driver.FindElement(By.Id("signInSubmit"));
        public IWebElement AuthenicatedRequiredHeading => Driver.FindElement(By.XPath("//h1[contains(text(),'Authentication required')]"));

        public bool IsLoaded
        {

            get
            {
                var isLoaded = Driver.Url.Contains("signin?openid.pape");
                Reporter.LogTestStepForBugLogger(Status.Info, "Validate whether the Amazon Sign In Page loaded successfully.");
                _logger.Trace($"Sign In page is loaded=>{isLoaded}");
                return isLoaded;
            }
        }

        public void LogIn(string email, string password)
        {
            EmailTextField.Clear();
            EmailTextField.SendKeys(email);
      
            ContinueBtn.Click();

            PasswordTextField.Clear();
            PasswordTextField.SendKeys(password);
            SignInSubmitBtn.Click();
        }

    }
}
