using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementInteractions
{
    [TestClass]
    [TestCategory("Locating web elements")]
    public class IdentifyingWebElements_QTV
    {
        public IWebDriver Driver { get; private set; }
        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
        }
        [TestMethod]
        public void DifferentTypesOfSeleniumLocationStrategies()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            HighlightElementUsingJavaScript(By.ClassName("buttonClass"));
            HighlightElementUsingJavaScript(By.Id("idExample"));
            HighlightElementUsingJavaScript(By.LinkText("Click me using this link text!"));
            HighlightElementUsingJavaScript(By.Name("button1"));
            HighlightElementUsingJavaScript(By.PartialLinkText("link text!"));
            HighlightElementUsingJavaScript(By.TagName("div"));
            HighlightElementUsingJavaScript(By.CssSelector("#idExample"));
            HighlightElementUsingJavaScript(By.CssSelector(".buttonClass"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='idExample']"));
            HighlightElementUsingJavaScript(By.XPath("//*[@class='buttonClass']"));
        }

        /*
         Highlight this link using all of the different location strategies
             */
        [TestMethod]
        public void SeleniumLocationStrategiesQuiz()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            var link = Driver.FindElements(By.ClassName("et_pb_blurb_description"))[4];
            //HighlightElementUsingJavaScript(By.ClassName("et_pb_blurb_description"));
            HighlightElementUsingJavaScript(By.Id("simpleElementsLink"));
            HighlightElementUsingJavaScript(By.LinkText("Click this link"));
            HighlightElementUsingJavaScript(By.Name("clickableLink"));
            HighlightElementUsingJavaScript(By.PartialLinkText("Click this lin"));
            HighlightElementUsingJavaScript(By.TagName("a"));
            HighlightElementUsingJavaScript(By.CssSelector("#simpleElementsLink"));
            HighlightElementUsingJavaScript(By.XPath("//*[@id='simpleElementsLink']"));
        }



        private void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = Driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor JavaScriptExecutor = Driver as IJavaScriptExecutor;
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }
        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void SeleniumElementLocationExam()
        {

            /*
             *-Using only XPath!!
             -When debugging and testing, make sure that you scroll the element into view, Selenium
             will not scroll for you. Not yet...
             */
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            //click any radio button, hint:  FindElement().Click();
            Driver.FindElement(By.XPath("//*[@type='radio'][@value='male']")).Click();
            //select one checkbox
            Driver.FindElement(By.XPath("//*[@value='Bike']")).Click();
            //select Audi from the dropdown
            Driver.FindElement(By.TagName("select")).Click();
            Driver.FindElement(By.XPath("//*[@value='audi']")).Click();
            //open Tab2 and assert that it is opened. Hint, use .Text property when you find the element
            Driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']")).Click();
            Assert.AreEqual("Tab 2 content",
                Driver.FindElement(By.XPath("//*[@class='et_pb_tab clearfix et_pb_tab_1 et-pb-active-slide']")).Text);
            //in the HTML Table with id, highlight one of the salary cells
            HighlightElementUsingJavaScript(By.XPath("//td[contains(text(),'$150,000+')]"));

            //Highlight the center section called "Highlight me", but you can only
            //highlight the highest level div for that element. The top parent div.
            //Hint, this is the class - 
            //et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough
            HighlightElementUsingJavaScript(By.ClassName("et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough"));
            HighlightElementUsingJavaScript(
                By.XPath("//*[@class='et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough']"));
        }

        [TestMethod]
        public void Test_Navigation_QTV()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            //Driver.Navigate().Forward();
           // Driver.Navigate().Back();
            //Driver.Navigate().Refresh();
            Assert.AreEqual("Simple HTML Elements For Automation - Ultimate QA", Driver.Title);
        }

        [TestMethod]
        public void FillingOutForm_Test_QTV()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            Driver.FindElement(By.Id("et_pb_contact_name_1")).Clear();
            Driver.FindElement(By.Id("et_pb_contact_name_1")).SendKeys("Quang");

            Driver.FindElement(By.Name("et_pb_contact_message_1")).Clear();
            Driver.FindElement(By.Name("et_pb_contact_message_1")).SendKeys("Vo");

            Driver.FindElement(By.Name("et_pb_contact_captcha_1")).Clear();
            Driver.FindElement(By.Name("et_pb_contact_captcha_1")).SendKeys("26");

            Driver.FindElement(By.XPath("//button[@type='submit'][@name='et_builder_submit_button']")).Click();
            
        }

        [TestMethod]
        public void Test_Navigation_QTV2()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/Automation/");
            //Driver.Navigate().Forward();
            // Driver.Navigate().Back();
            //Driver.Navigate().Refresh();
            Driver.FindElement(By.XPath("//*[@href='/complicated-page']")).Click();
           // Assert.AreEqual("Simple HTML Elements For Automation - Ultimate QA", Driver.Title);
        }

        //[testmethod]
        //public void xpath_exam_qtv()
        //{
        //    driver.navigate().gotourl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
        //    thread.sleep(2000);
        //    click on a radio button
        //   highlightelementusingjavascript(by.xpath("//input[@name='gender'][@value='female']"));
        //    driver.findelement(by.xpath("//input[@type='radio'][@value='female']")).click();
        //    driver.findelement(by.xpath("//td[contains(text(), '$150,000+')]")).click();
        //    driver.findelement(by.tagname("select")).click();
        //    driver.findelement(by.xpath("//option[@value='volvo']")).click();

        //}
    }
}
