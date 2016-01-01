using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WJStore.Test.Controllers
{
    [TestClass]
    public class ShoppingTest : SeleniumTest
    {

        public ShoppingTest() : base("WJStore") { }

        [TestMethod]
        public void IndexIETest()
        {
            // Act
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/home/index"));
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Storemanager"));
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Account/Logoff"));
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Storemanager"));

            /* Registeration If Needed
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Account/Register"));
            this.InternetExplorerDriver.FindElement(By.Id("UserName")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("UserName")).SendKeys("Shervin");
            this.InternetExplorerDriver.FindElement(By.Id("Email")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("Email")).SendKeys("Shervin@Gmail.com");
            this.InternetExplorerDriver.FindElement(By.Id("Password")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("Password")).SendKeys("123456789");
            this.InternetExplorerDriver.FindElement(By.Id("ConfirmPassword")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456789");
            this.InternetExplorerDriver.FindElement(By.Id("RegisterBtnReg")).Click();
            */
            /* Sign In Process */
            this.InternetExplorerDriver.FindElement(By.Id("UserName")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("UserName")).SendKeys("Teacher1");
            this.InternetExplorerDriver.FindElement(By.Id("Password")).Clear();
            this.InternetExplorerDriver.FindElement(By.Id("Password")).SendKeys("teacherpass");
            this.InternetExplorerDriver.FindElement(By.Id("SignInBtn")).Click();

            /* Store Process */
            this.InternetExplorerDriver.FindElement(By.Id("Store")).Click();
            this.InternetExplorerDriver.FindElement(By.Id("SearchTextBox")).SendKeys("apple");
            this.InternetExplorerDriver.FindElement(By.Id("Search")).Click();
            this.InternetExplorerDriver.Navigate().GoToUrl(this.GetAbsoluteUrl("/Store/Details/1"));

            /* Add to Cart */
            this.InternetExplorerDriver.FindElement(By.Id("AddToCart")).Click();
            string firstItem = this.InternetExplorerDriver.FindElement(By.Id("firstItem")).FindElement(By.TagName("a")).Text;

            Assert.AreEqual(firstItem, "/Store/Details/1", true);
        }
    }
}
