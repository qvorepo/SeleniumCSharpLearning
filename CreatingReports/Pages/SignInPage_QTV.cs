using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;

namespace CreatingReports.Pages
{
    internal class SignInPage_QTV: BaseApplicationPage
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public SignInPage_QTV(IWebDriver driver) : base(driver)
        {
        }
    }
}
