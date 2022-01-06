using NUnit.Framework;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Task40Nunit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCaseSource("LoginTestData")]
        public void Test1(string username, string password)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            driver.Navigate().GoToUrl("https://mail.ru/");

            var usernameBox = driver.FindElement(By.ClassName("email-input"));
            usernameBox.SendKeys(username);

            var domainBox = driver.FindElement(By.XPath("//option[@value='@inbox.ru']"));
            domainBox.Click();

            var enterForPasButton = driver.FindElement(By.XPath("//button[@data-testid ='enter-password']"));
            enterForPasButton.Click();

            var inputPress = driver.FindElement(By.ClassName("password-input"));

            // it is not waiter. Thread.Sleep used to suspend the execution of the current thread for a specified time in milliseconds
            Thread.Sleep(3000);
            inputPress.SendKeys(password);

            var secondButton = driver.FindElement(By.ClassName("second-button"));
            secondButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(condition =>
            {
                try
                {
                  Assert.IsTrue(driver.FindElement(By.CssSelector(".filters-control__filter-text")).Displayed, "Element Filter is not displayed");
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            

            driver.Close();
        }
        static object[] LoginTestData =
        {
           new object[] {"vikavika234", "polinka145b" },
           new object[] {"vikavika546", "polinka145ggh" }
        };
    }
}