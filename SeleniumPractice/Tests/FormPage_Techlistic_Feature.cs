using SeleniumPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumPractice.Tests
{
    [TestClass]
    [TestCategory("FormPage")]
    [TestCategory("FormPage")]
    public class FormPage_Techlistic_Feature : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "QuangVo")]
        [Description("Validate that the form page opens.")]
        public void TCID2()
        {
            var formPage = new FormPage_Techlistic(Driver);
            formPage.GoTo();
            Assert.IsTrue(formPage.IsLoaded, 
                "The form page did not open successfully.");
        }

        [TestMethod]
        [TestProperty("Author", "Quang Vo")]
        [Description("Validate that the form page is filled out properly.")]
        public void TCID4()
        {
            var formPage = new FormPage_Techlistic(Driver);
            formPage.GoTo();
            Assert.IsTrue(formPage.IsLoaded, "Form page did not open successfully");

            formPage.FillOutForm("Quang", "Vo");
            //Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open successfully.");
            
        }
    }
}