using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthStandard.Pages
{
    public class SeleniumHomePage : BasePage
    {
        public SeleniumHomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToHomePage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
