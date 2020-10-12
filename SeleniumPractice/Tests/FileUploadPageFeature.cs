using SeleniumPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoItX3Lib;

namespace SeleniumPractice.Tests
{
    [TestClass]
    [TestCategory("FileUploadPage")]
    [TestCategory("SeleniumPractice")]
    public class FileUploadPageFeature : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "QuangVo")]
        [Description("Validate that the File Upload page opens successfully with a form.")]
        public void VerifyFileUpload()
        {
            var fileUploadPage = new FileUploadPage(Driver);
            fileUploadPage.GoTo();
            Assert.IsTrue(fileUploadPage.IsLoaded,
                "The File Upload page did not open successfully.");

            fileUploadPage.UploadFile();
        }

 

    }
}