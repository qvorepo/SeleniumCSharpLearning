using AutoItX3Lib;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumPractice.Pages
{
    internal class FileUploadPage : BaseApplicationPage
    {
        public FileUploadPage(IWebDriver driver) : base(driver)
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
                    return Driver.Title.Contains("File Upload Demo");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement ChooseFile => Driver.FindElement(By.XPath("//input[@type='file']"));
        //closeBtn
        public IWebElement CloseBtn => Driver.FindElement(By.Id("closeBtn"));


        internal void GoTo()
        {
            var url = "http://demo.guru99.com/test/upload/";
            Driver.Navigate().GoToUrl(url);
            
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for File Upload page.");
            Thread.Sleep(1000);
            CloseBtn.Click();

        }

        internal void UploadFile()
        {
            ChooseFile.Click();

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            //Thread.Sleep(2000);
            autoIt.Send(@"C:\Users\Mamga\source\Github\LightPomFrameworkTutorial-master\SeleniumPractice\TestData\TestUpload.txt");
            //Thread.Sleep(2000);
            autoIt.Send("{ENTER}");
        }
    }
}