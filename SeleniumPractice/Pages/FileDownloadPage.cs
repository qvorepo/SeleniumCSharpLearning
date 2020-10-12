using AutoItX3Lib;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Threading;
using AutomationResources;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractice.Pages
{
    internal class FileDownloadPage : BaseApplicationPage
    {
        public FileDownloadPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that File Upload page loaded successfully.");
                    //var displayed = CenterColumn.Displayed;
                   // return displayed;
                    return Driver.Title.Contains("Notepad++");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public bool IsVerionCorrect
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that File Release page loaded successfully.");
                    //var displayed = CenterColumn.Displayed;
                    // return displayed;
                    return Driver.Title.Contains("7.8.7");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        string expectedFilePath = @"C:\Users\Mamga\Downloads\npp.7.8.7.Installer.x64.exe";
        bool fileExists = false;

        public IWebElement DownloadLink => Driver.FindElement(By.LinkText("Download"));

        public IWebElement Release_7_8_7 => Driver.FindElement(By.XPath("//a[@href='https://notepad-plus-plus.org/downloads/v7.8.7/']"));

        public IWebElement DownloadList => Driver.FindElement(By.XPath("//ul[@className='patterns-list']"));

        public IWebElement Release_7_8_7_URL => Driver.FindElement(By.XPath("//a[@href='https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v7.8.7/npp.7.8.7.Installer.x64.exe']"));

        public By DownloadListByXpath = By.XPath("//ul[@className='patterns-list']");
        


        internal void GoTo()
        {

            var url = "https://notepad-plus-plus.org/";
            Driver.Navigate().GoToUrl(url);
            
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for File Download page.");
            
        }

        internal void ClickDownloadLink()
        {
            DownloadLink.Click();
            Util.WaitUntilElementIsDisplayed(DownloadListByXpath, 10, Driver);
            
           
        }
        internal void ClickRelease7_8_7()
        {
            Release_7_8_7.Click();
            
        }

        internal void ClickRelease7_8_7_Installer()
        {
            try {
                Release_7_8_7_URL.Click();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
                wait.Until<bool>(x => fileExists = File.Exists(expectedFilePath));
                FileInfo fileInfo = new FileInfo(expectedFilePath);
                Assert.AreEqual(3955, fileInfo.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(File.Exists(expectedFilePath))
                {
                    File.Delete(expectedFilePath);
                }
            }

        }
            
    }
}