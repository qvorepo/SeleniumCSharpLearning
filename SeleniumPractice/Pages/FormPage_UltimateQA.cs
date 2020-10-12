using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SeleniumPractice.Pages
{
    internal class FormPage_UltimateQA : BaseApplicationPage
    {
        public FormPage_UltimateQA(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                        "Validate that Form page loaded successfully.");
                    //var displayed = CenterColumn.Displayed;
                    return Driver.Title.Contains("Simple HTML Elements For Automation - Ultimate QA");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement RadioFemaleBtn => Driver.FindElement(By.XPath("input[@type='radio'][@name='gender'][@value='female']"));
        public IWebElement NameTextField => Driver.FindElement(By.Id("et_pb_contact_name_0"));
        public IWebElement EmailTextField => Driver.FindElement(By.Name("et_pb_contact_email_0"));

        
        public IWebElement VehicleCarCheckbox => Driver.FindElement(By.XPath("input[@type = 'checkbox'][@name = 'vehicle'][@value = 'Car']"));

        internal void GoTo()
        {
            var url = "https://ultimateqa.com/simple-html-elements-for-automation/";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Form page.");
        }

        internal void FillOutForm(string name, string email)
        {

            //RadioFemaleBtn.Click();

            NameTextField.Clear();
            NameTextField.SendKeys(name);

            EmailTextField.Clear();
            EmailTextField.SendKeys(email);

            VehicleCarCheckbox.Click();
        }
    }
}