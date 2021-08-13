using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QA_TestProject.JSAlertPages;
using QA_TestProject.Pages;
using System;
using System.Collections.Generic;

namespace QA_TestProject
{
    public class ComputerDataBaseTests
    {
        static IWebDriver driver = null;

        [SetUp]
        public void Setup()
        {
            string computerDbURL = "http://computer-database.gatling.io/computers";

            //Driver setup
            driver = new ChromeDriver(@"C:\Driver");

            //Navigate to URL
            driver.Navigate().GoToUrl(computerDbURL);
        }

        [Test]
        public void Test1_CreateNewComp()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            AddNewComp addNewComp = new AddNewComp(driver);

            //Variables
            string compName = "IBM 5100";
            string introDate = "1975-09-01";
            string discoDate = "1982-03-01";
            string company = "IBM";
            
            
            compHomePage.AddNewComp();
            addNewComp.EnterDetails(compName, introDate, discoDate, company);
                
            string alertMsg = compHomePage.AlertMessage();
            //Console.WriteLine(alertMsg);
            if(alertMsg == "Done ! Computer "+compName+" has been created")
            {
                Console.WriteLine("Successfully created a new computer");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to create a new computer");
                Assert.Fail();
            }
        }

        [Test]
        public void Test2_ReadCompDetail()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            AddNewComp addNewComp = new AddNewComp(driver);

            //Variables
            string compName = "IBM 650";

            List<string> compInfoList = compHomePage.FilterByName(compName);

            if(compInfoList[0].Contains(compName))
            {
                Console.WriteLine("Successfully read the computer information");
                Console.WriteLine("Computer Name     : " + compInfoList[0]);
                Console.WriteLine("Introduced Date   : " + compInfoList[1]);
                Console.WriteLine("Discontinued Date : " + compInfoList[2]);
                Console.WriteLine("Company           : " + compInfoList[3]);
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to read the computer information");
                Assert.Fail();
            }
        }

        [Test]
        public void Test3_UpdateCompDetail()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            EditComp editComp = new EditComp(driver);

            //Variables
            string compName = "IBM 650";
            string introDate = "1953-06-01";
            string discoDate = "1969-08-18";
            string company = "IBM";

            compHomePage.FilterByName(compName);
            compHomePage.SelectComp(compName);
            

            editComp.EditDetails(compName, introDate, discoDate, company);

            string alertMsg = compHomePage.AlertMessage();
            Console.WriteLine(alertMsg);
            if (alertMsg == "Done ! Computer "+compName+" has been updated")
            {
                Console.WriteLine("Successfully updated the computer information");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to update the computer information");
                Assert.Fail();
            }
        }
        [Test]
        public void Test4_UpdateIncorrectDateFormat()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            EditComp editComp = new EditComp(driver);

            //Variables
            string compName = "IBM 650";
            string introDate = "1953/06/01";
            string discoDate = "1969/08/18";
            string company = "IBM";

            compHomePage.FilterByName(compName);
            compHomePage.SelectComp(compName);


            bool state = editComp.EditDetails(compName, introDate, discoDate, company);

            if (state == false)
            {
                Console.WriteLine("Successfully detected input error");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to detect input error");
                Assert.Fail();
            }
        }

        [Test]
        public void Test5_DeleteComp()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            EditComp editComp = new EditComp(driver);

            //Variables
            string compName = "IBM 650";

            compHomePage.FilterByName(compName);
            compHomePage.SelectComp(compName);
            editComp.DeleteComp();

            string alertMsg = compHomePage.AlertMessage();
            //Console.WriteLine(alertMsg);
            if (alertMsg == "Done ! Computer " + compName + " has been deleted")
            {
                Console.WriteLine("Successfully deleted the computer information");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to delete the computer information");
                Assert.Fail();
            }
        }
        [Test]
        public void Test6_SearchNonExistentComp()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            AddNewComp addNewComp = new AddNewComp(driver);

            //Variables
            string compName = "wasd";

            List<string> compInfoList = compHomePage.FilterByName(compName);
            //Console.WriteLine(compInfoList.Count);
            if (compInfoList.Count == 0)
            {
                Console.WriteLine("Nothing to display as expected");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Unexpected result");
                Assert.Fail();
            }
        }

        [Test]
        public void Test7_SearchPartialName()
        {
            //Create an instance of the necessary classes
            CompHomePage compHomePage = new CompHomePage(driver);
            AddNewComp addNewComp = new AddNewComp(driver);

            //Variables
            string compName = "IBM";

            List<string> compInfoList = compHomePage.FilterByName(compName);

            if (compInfoList[0].Contains(compName))
            {
                Console.WriteLine("Successfully read the computer information");
                Console.WriteLine("Computer Name     : " + compInfoList[0]);
                Console.WriteLine("Introduced Date   : " + compInfoList[1]);
                Console.WriteLine("Discontinued Date : " + compInfoList[2]);
                Console.WriteLine("Company           : " + compInfoList[3]);
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to read the computer information");
                Assert.Fail();
            }
        }

        [TearDown]
        public void TearDown() => driver.Quit();
    }

    public class JSAlertTests
    {
        static IWebDriver driver = null;

        [SetUp]
        public void Setup()
        {
            string jsAlertsURL = "https://the-internet.herokuapp.com/javascript_alerts";

            //Driver setup
            driver = new ChromeDriver(@"C:\Driver");

            //Navigae to URL
            driver.Navigate().GoToUrl(jsAlertsURL);
        }

        [Test]
        public void Test1_ClickJSAlert()
        {
            //Create an instance of the necessary classes
            JSHomePage jsHomePage = new JSHomePage(driver);

            jsHomePage.ClickJSAlert();
            string resultMsg = jsHomePage.Result();
            
            if(resultMsg == "You successfully clicked an alert")
            {
                Console.WriteLine("Successfully clicked an alert");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to click an alert");
                Assert.Fail();
            }

            Assert.Pass();
        }
        [Test]
        public void Test2_ClickJSConfirm()
        {
            //Create an instance of the necessary classes
            JSHomePage jsHomePage = new JSHomePage(driver);

            jsHomePage.ClickJSConfirm();
            string resultMsg = jsHomePage.Result();

            if (resultMsg == "You clicked: Ok")
            {
                Console.WriteLine("Successfully clicked Ok");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to click Ok");
                Assert.Fail();
            }

            Assert.Pass();
        }
        [Test]
        public void Test3_CancelJSConfirm()
        {
            //Create an instance of the necessary classes
            JSHomePage jsHomePage = new JSHomePage(driver);

            jsHomePage.CancelJSConfirm();
            string resultMsg = jsHomePage.Result();

            if (resultMsg == "You clicked: Cancel")
            {
                Console.WriteLine("Successfully cancelled an alert");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to cancel an alert");
                Assert.Fail();
            }

            Assert.Pass();
        }
        [Test]
        public void Test4_ClickJSPrompt()
        {
            //Create an instance of the necessary classes
            JSHomePage jsHomePage = new JSHomePage(driver);
            
            //Variable
            string promptMsg = "testing 1 2 3";

            jsHomePage.ClickJSPrompt(promptMsg);
            string resultMsg = jsHomePage.Result();

            if (resultMsg == "You entered: "+promptMsg)
            {
                Console.WriteLine("Successfully enetered a prompt");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to enter a promt");
                Assert.Fail();
            }

            Assert.Pass();
        }
        [Test]
        public void Test5_CancelJSPrompt()
        {
            //Create an instance of the necessary classes
            JSHomePage jsHomePage = new JSHomePage(driver);

            //Variable
            string promptMsg = "testing 1 2 3";

            jsHomePage.CancelJSPrompt();
            string resultMsg = jsHomePage.Result();

            if (resultMsg == "You entered: null")
            {
                Console.WriteLine("Successfully cancelled a prompt");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Failed to cancel a promt");
                Assert.Fail();
            }

            Assert.Pass();
        }

        [TearDown]
        public void TearDown() => driver.Quit();
    }
}