using SeleniumPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoItX3Lib;
using System.IO;

namespace SeleniumPractice.Tests
{
    [TestClass]
    [TestCategory("FileDownloadPage")]
    [TestCategory("SeleniumPractice")]
    public class FileDonwloadPageFeature : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "QuangVo")]
        [Description("Validate that the File Download page opens successfully with a form.")]
        public void VerifyFileDownload()
        {
            var fileDownloadPage = new FileDownloadPage(Driver);
            fileDownloadPage.GoTo();
            Assert.IsTrue(fileDownloadPage.IsLoaded,
                "The File Download page did not open successfully.");

            fileDownloadPage.ClickDownloadLink();
            fileDownloadPage.ClickRelease7_8_7();
            Assert.IsTrue(fileDownloadPage.IsVerionCorrect,
               "The File Release 7.8.7 page did not open successfully.");

            fileDownloadPage.ClickRelease7_8_7_Installer();
        }

 

    }
}