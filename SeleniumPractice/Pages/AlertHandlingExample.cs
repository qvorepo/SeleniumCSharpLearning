using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;

namespace SeleniumPractice.Pages
{
    [TestClass]
    [TestCategory("AlertHandling")]
    public class AlertHandlingExample
    {

        IWebDriver driver;
        [TestMethod]
        [Description("SimpleAlertTest")]
        [TestProperty("Author", "Quang Vo")]

        public void SimpleAlert()
         {
            try
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.toolsqa.com/handling-alerts-using-selenium-webdriver/");
                driver.Manage().Window.Maximize();
                driver.FindElement(By.XPath("//button[.='Simple Alert']")).Click();
                IAlert myAlert = driver.SwitchTo().Alert();
                Debug.WriteLine(myAlert.Text);
                myAlert.Accept();
                driver.SwitchTo().DefaultContent();
            }

            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                driver.Quit();
            }

        }
    }
}
