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
        public void IndexFirefoxTest()
        {
            // Act
            this.FirefoxDriver.Navigate().GoToUrl(this.GetAbsoluteUrl(""));
        }
    }
}
