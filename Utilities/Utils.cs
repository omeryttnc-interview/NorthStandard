using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthStandard.Pages;
using NUnit.Framework;

namespace NorthStandard.Utilities
{
    public static class Utils
    {
        public static void AssertTitle(string expectedTitle)
        {
            string actualTitle = DriverManager.Driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match!");
        }
    }
}
