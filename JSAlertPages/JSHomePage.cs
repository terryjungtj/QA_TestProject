using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA_TestProject.JSAlertPages
{
    class JSHomePage
    {
        public JSHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        private By JSAlertBtn = By.XPath("//button[@onclick='jsAlert()']");
        private By JSConfirmBtn = By.XPath("//button[@onclick='jsConfirm()']");
        private By JSPromptBtn = By.XPath("//button[@onclick='jsPrompt()']");
        private By ResultTxt = By.Id("result");


        public void ClickJSAlert()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(JSAlertBtn));
                Driver.FindElement(JSAlertBtn).Click();
                Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find JS alert button");
                Assert.Fail();
            }
        }
        public void ClickJSConfirm()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(JSConfirmBtn));
                Driver.FindElement(JSConfirmBtn).Click();
                Driver.SwitchTo().Alert().Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find JS confirm button");
                Assert.Fail();
            }
        }
        public void CancelJSConfirm()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(JSConfirmBtn));
                Driver.FindElement(JSConfirmBtn).Click();
                Driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find JS confirm button");
                Assert.Fail();
            }
        }
        public void ClickJSPrompt(string promptTxt)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(JSPromptBtn));
                Driver.FindElement(JSPromptBtn).Click();

                var alertWindow = Driver.SwitchTo().Alert();
                alertWindow.SendKeys(promptTxt);
                alertWindow.Accept();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find JS prompt button");
                Assert.Fail();
            }
        }
        public void CancelJSPrompt()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(JSPromptBtn));
                Driver.FindElement(JSPromptBtn).Click();

                var alertWindow = Driver.SwitchTo().Alert();
                alertWindow.Dismiss();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find JS prompt button");
                Assert.Fail();
            }
        }

        public string Result()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            try
            {
                wait.Until(ExpectedConditions.ElementExists(ResultTxt));
                return Driver.FindElement(ResultTxt).Text;
            }
            catch (Exception e)
            {
                Assert.Fail();
                return null;
            }
        }
    }
}
