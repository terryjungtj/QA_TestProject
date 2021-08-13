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
    class EditComp
    {
        //Constructor
        public EditComp(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        
        //By element variables
        private By nameTf = By.Id("name");
        private By introDateTf = By.Id("introduced");
        private By discoDateTf = By.Id("discontinued");
        private By compnayDd = By.Id("company");
        private By deleteBtn = By.XPath("//input[@value='Delete this computer']");
        private By saveBtn = By.XPath("//input[@value='Save this computer']");
        private By cancelBtn = By.LinkText("Cancel");
        private By inputError = By.CssSelector(".error .help-inline");


        //Takes four string inputs and makes changes to the selected computer
        public bool EditDetails(string computerName, string introductionDate, string discontinuationDate, string companyName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

            //Try to save the update
            try
            {
                wait.Until(ExpectedConditions.ElementExists(saveBtn));
                Driver.FindElement(nameTf).Clear();
                Driver.FindElement(nameTf).SendKeys(computerName);
                Driver.FindElement(introDateTf).Clear();
                Driver.FindElement(introDateTf).SendKeys(introductionDate);
                Driver.FindElement(discoDateTf).Clear();
                Driver.FindElement(discoDateTf).SendKeys(discontinuationDate);
                new SelectElement(Driver.FindElement(compnayDd)).SelectByText(companyName);
                Driver.FindElement(saveBtn).Click();
                //Console.WriteLine("success");

                //Try to check if input error message exists
                try
                {
                    wait.Until(ExpectedConditions.ElementExists(inputError));
                    string error = Driver.FindElement(inputError).Text;
                    Console.WriteLine(error);
                    Driver.FindElement(cancelBtn).Click();
                    return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not edit computer");
                Assert.Fail();
                return false;
            }
        }

        //Deletes the selected computer
        public void DeleteComp()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(deleteBtn));
                Driver.FindElement(deleteBtn).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not delete computer");
                Assert.Fail();
            }
        }
    }
}
