using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumPractice.Pages;
using SeleniumPractice.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SeleniumPractice.Tests
{
    [TestClass]
    [TestCategory("ExcelLibHelperFeature")]
 
    public class ExcelLibHelperFeature
    {
        [TestMethod]
        [Description("Read Excel test.")]
        [TestProperty("Author", "Quang Vo")]
        public void TCID_01_ReadDataFromExcelTest()
        {
            
            try
            {
                ExcelLibHelper.PopulateInCollection(@"C:\Users\Mamga\source\Github\LightPomFrameworkTutorial-master\SeleniumPractice\TestData\UserInfo.xlsx", "Sheet1");
                Debug.WriteLine("*****************");
                Debug.WriteLine("First Person First Name is: " + ExcelLibHelper.ReadData(1, "FirstName"));
                Debug.WriteLine("First Person Last Name is: " + ExcelLibHelper.ReadData(1, "LastName"));
                Debug.WriteLine("First Person Initial is: " + ExcelLibHelper.ReadData(1, "Initial"));

                Debug.WriteLine("Second Person First Name is: " + ExcelLibHelper.ReadData(2, "FirstName"));
                Debug.WriteLine("Second Person Last Name is: " + ExcelLibHelper.ReadData(2, "LastName"));
                Debug.WriteLine("Second Person Initial is: " + ExcelLibHelper.ReadData(2, "Initial"));
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
  
        }
    }
}
