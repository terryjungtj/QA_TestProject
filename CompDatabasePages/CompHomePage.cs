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
    class CompHomePage
    {
        //Constructor
        public CompHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //By element variables
        private By addNewComp = By.Id("add");
        private By filterByNameTf = By.Id("searchbox");
        private By filterByNameBtn = By.Id("searchsubmit");
        private By alertMessage = By.CssSelector(".alert-message");
        private By table = By.XPath("//*[@id='main']/table/tbody");
        
        //Clicks the create button
        public void AddNewComp()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            
            try
            {   
                wait.Until(ExpectedConditions.ElementExists(addNewComp));
                Driver.FindElement(addNewComp).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the add button");
                Assert.Fail();
            }
        }
        
        //Takes one string input and searches for the computer name in the database.
        //If more than one entries are found, only the first entry will be considered.
        //Returns a list containing the name, intro date, discontinued date and compnay.
        public List<string> FilterByName(string compName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            List<string> compInfoList = new List<string>();

            //Enter and search computer name in the searchbox
            try
            {
                wait.Until(ExpectedConditions.ElementExists(filterByNameBtn));
                Driver.FindElement(filterByNameTf).SendKeys(compName);
                Driver.FindElement(filterByNameBtn).Click();

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the filter button");
                Assert.Fail();
                return compInfoList;
            }


            try
            {
                wait.Until(ExpectedConditions.ElementExists(table));
                IWebElement dbtable = Driver.FindElement(table);
                //add the table rows to an ilist
                IList<IWebElement> tableRow = dbtable.FindElements(By.TagName("tr"));

                //add the columns of the corresponding row to an ilist
                IList<IWebElement> tableCol = tableRow[0].FindElements(By.TagName("td"));

                //Console.WriteLine(tableRow.Count);
                //Console.WriteLine(tableCol.Count);
                for (int i = 0; i < tableCol.Count(); i++)
                {
                    //iterate through the ilist and convert the webelement to a string
                    //and add it to a string list 
                    string cell = tableCol[i].Text;
                    //Console.WriteLine(cell);
                    compInfoList.Add(cell);
                }

                return compInfoList;
            }
            catch (Exception e)
            {
                return compInfoList;
            }

        }
        
        //Clicks the desired computer name
        public void SelectComp(string compName)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.LinkText(compName)));
                Driver.FindElement(By.LinkText(compName)).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the link text");
                Assert.Fail();
            }
        }
        
        //Reads the alert message and returns it as a string
        public string AlertMessage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(alertMessage));
                return Driver.FindElement(alertMessage).Text;
            }
            catch
            {
                Console.WriteLine("No alert message");
                return null;
            }
        }           
    }
}
