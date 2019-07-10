﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
        protected IWebDriver Driver;
        private static string VendorDirectory;

        [SetUp]
        public new void SetUp()
        {
            VendorDirectory = System.IO.Directory.GetParent(
                                System.AppContext.BaseDirectory).
                                Parent.Parent.Parent.FullName
                                + @"/vendor";
            var Service = FirefoxDriverService.CreateDefaultService(VendorDirectory);
            Driver = new FirefoxDriver(Service);
        }

        [Test]
        public void ValidAccount()
        {
            Driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            Driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            Driver.FindElement(By.CssSelector("button")).Click();
            Assert.That(Driver.FindElement(By.CssSelector(".flash.success")).Displayed);
        }
    }
}
