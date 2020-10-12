using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatingReports.Pages;
using OpenQA.Selenium;


namespace CreatingReports.Pages
{
    public class LeftPageSection_QTV : BaseApplicationPage
    {
        public LeftPageSection_QTV(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement SearchForm => Driver.FindElement(By.XPath("//form[@id='searchform']"));
        //public IWebElement SearchForm => Driver.FindElements(By.XPath("//form[@role='search']"))[1];
        public IWebElement SearchBox => Driver.FindElements(By.XPath("//form[@role='search']//input[@id='s']"))[0];
        public IWebElement SearchButton => SearchForm.FindElement(By.Id("searchsubmit"));

        public SearchResultsPage Search(string searchString)
        {
            SearchBox.SendKeys(searchString);
            SearchButton.Click();
            Reporter.LogPassingTestStepToBugLogger($"Search for string =>{searchString} in the left search bar.");

            return new SearchResultsPage(Driver);
        }
    }
}
