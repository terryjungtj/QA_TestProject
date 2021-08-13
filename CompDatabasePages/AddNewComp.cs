using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA_TestProject.Pages
{
    class AddNewComp
    {
        //Constructor
        public AddNewComp(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //By element variables
        private By nameTf   = By.Id("name");
        private By introDateTf = By.Id("introduced");
        private By discoDateTf = By.Id("discontinued");
        private By compnayDd = By.Id("company");
        private By createBtn = By.XPath("//input[@value='Create this computer']");

        public void EnterDetails(string computerName, string introductionDate, string discontinuationDate, string companyName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(createBtn));
                Driver.FindElement(nameTf).SendKeys(computerName);
                Driver.FindElement(introDateTf).SendKeys(introductionDate);
                Driver.FindElement(discoDateTf).SendKeys(discontinuationDate);
                new SelectElement(Driver.FindElement(compnayDd)).SelectByText(companyName);
                Driver.FindElement(createBtn).Click();
                //Console.WriteLine("success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create new computer");
                Assert.Fail();
            }
        }
    }
}
