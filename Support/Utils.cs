using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NorthStandard.Support
{
    internal class Utils
    {
        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The text of an element.</param>

        public static void ClickElementByText(IWebDriver driver, string text)
        {
            // Find elements by XPath that contains the text
            driver.FindElement(By.XPath($"//*[text()='{text}']")).Click();
        }

        static Func<string, By> ReturnXPathIfTextGiven = (text) => By.XPath($"//*[text()='{text}']");

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The XPath of the element to wait for and click.</param>
        /// <param name="timeoutInSeconds">The maximum time to wait in seconds.</param>
        public static void WaitForElementAndClick(IWebDriver driver, string text, string locatorType, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            switch (locatorType.ToLower())
            {
                case "textlocator":
                    wait.Until(ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
                    break;
                case "idlocator":
                    wait.Until(ElementToBeClickable(By.Id(text))).Click();
                    break;
                case "xpath":
                    wait.Until(ElementToBeClickable(By.XPath(text))).Click();
                    break;
                case "linktext":
                    wait.Until(ElementToBeClickable(By.LinkText(text))).Click();
                    break;
                default:
                    throw new ArgumentException("Invalid locator type");
            }

        }

        public static void WaitForElementAndClick(IWebDriver driver, string text, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
        }


        /// <summary>
        /// Selects an option from a dropdown by visible text.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locatorText">locator text as XPath.</param>
        /// <param name="visibleText">The visible text of the option to be selected.</param>
        public static void SelectFromDropdownByGivenLocator(IWebDriver driver, string locatorText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.XPath(locatorText)));
            select.SelectByText(visibleText);
        }
        public static void SelectFromDropdownByGivenId(IWebDriver driver, string idText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.Id(idText)));
            select.SelectByText(visibleText);
        }

        public static void ClickByHoverOverAndActions(IWebDriver driver, string xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ElementIsVisible(By.XPath(xpathLocator)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            driver.FindElement(By.XPath(xpathLocator)).Click();
        }
        private static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
        private static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return element.Displayed ? element : null;
            };
        }
    }
}
