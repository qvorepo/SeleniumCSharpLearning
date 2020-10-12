using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class SampleApplicationPage_QTV : BaseSampleApplicationPage
    {
        public SampleApplicationPage_QTV(IWebDriver driver) : base(driver){}

        public bool IsVisible {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }
        private string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));

        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement MaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='male']"));
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='other']"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-3/");
            Assert.IsTrue(IsVisible, 
                $"Sample application page was not visible. Expected=>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal UltimateQAHomePage FillOutFormAndSubmit (TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
 
            return new UltimateQAHomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
    }
}