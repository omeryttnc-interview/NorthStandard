using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NorthStandard.Utilities
{
    public static class WaitHelpers
    {
        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
