using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomationResources
{
    public static class Util
    {

        public static bool ElementIsDisplayed(By element, IWebDriver driver)
        {
            var present = false;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            try
            {
                present = driver.FindElement(element).Displayed;
               
            }
            catch (NoSuchElementException)
            {
            }
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            return present;
        }
        public static bool WaitUntilElementIsDisplayed(By element, int timeoutInSeconds, IWebDriver driver)
        {
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                if (ElementIsDisplayed(element, driver))
                {
                    return true;
                }
                System.Threading.Thread.Sleep(1000);
            }
            return false;
        }

    }
}
