using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumPractice.Pages
{
    internal class FormPage_Techlistic : BaseApplicationPage
    {
        public FormPage_Techlistic(IWebDriver driver) : base(driver)
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
                    return Driver.Title.Contains("Demo 'About Me' Web Form for Selenium Automation Practice");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement FirstNameTextField => Driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameTextField => Driver.FindElement(By.Name("lastname"));
        public IWebElement SexFemaleRadioBtn => Driver.FindElement(By.Id("sex-1"));

        public IWebElement ExperienceYear7RadioBtn => Driver.FindElement(By.Id("exp-6"));

        public IWebElement DateTextField => Driver.FindElement(By.Id("datepicker"));

        public IWebElement ToolSeleniumWebdriverCheckbox => Driver.FindElement(By.Id("tool-2"));

        public IWebElement ProfessionManualTesterCheckbox => Driver.FindElement(By.Id("profession-0"));

        public IWebElement Continents => Driver.FindElement(By.Id("continents"));

        public SelectElement ContinentsSelect => new SelectElement(Continents);

        public IWebElement SeleniumCommands => Driver.FindElement(By.Id("selenium_commands"));

        public SelectElement SeleniumCommandsSelect => new SelectElement(SeleniumCommands);

        internal void GoTo()
        {
            var url = "https://www.techlistic.com/p/selenium-practice-form.html";
            Driver.Navigate().GoToUrl(url);
            Reporter.LogPassingTestStepToBugLogger($"Open url=>{url} for Form page.");
        }

        internal void FillOutForm(string firstName, string lastName)
        {


            FirstNameTextField.Clear();
            FirstNameTextField.SendKeys(firstName);

            LastNameTextField.Clear();
            LastNameTextField.SendKeys(lastName);

            SexFemaleRadioBtn.Click();
            ProfessionManualTesterCheckbox.Click();
            ExperienceYear7RadioBtn.Click();
            ContinentsSelect.SelectByText("North America");

            SeleniumCommandsSelect.SelectByText("Wait Commands");
            SeleniumCommandsSelect.SelectByText("WebElement Commands");

            DateTextField.Clear();
            DateTextField.SendKeys(DateTime.Now.ToShortDateString());

            ToolSeleniumWebdriverCheckbox.Click();

         

        }
    }
}