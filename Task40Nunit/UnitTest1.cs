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
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.ru/");

            var usernameBox = driver.FindElement(By.ClassName("email-input"));
            usernameBox.SendKeys("vikavika234");

            var domainBox = driver.FindElement(By.XPath("//option[@value='@inbox.ru']"));
            domainBox.Click();

            var enterForPasButton = driver.FindElement(By.XPath("//button[@data-testid ='enter-password']"));
            enterForPasButton.Click();

            var inputPress = driver.FindElement(By.ClassName("password-input"));
            Thread.Sleep(3000);
            inputPress.SendKeys("polinka145b");

            var secondButton = driver.FindElement(By.ClassName("second-button"));
            secondButton.Click();

            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".filters-control__filter-text")).Displayed);

            driver.Close();
        }
    }
}