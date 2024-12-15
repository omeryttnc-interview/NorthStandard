using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NorthStandard.Utilities
{
    public static class DriverManager
    {
        [ThreadStatic]
        public static IWebDriver Driver;
        private static readonly ChromeOptions chromeOptions = new();
        private static readonly FirefoxOptions firefoxOptions = new();

        public static void InitializeDriver(string browser)

        {
            if (ConfigReader.GetAppSettings().IsHeadless)
            {
                chromeOptions.AddArguments("headless");
                firefoxOptions.AddArguments("headless");
            }
            Driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(chromeOptions),
                "firefox" => new FirefoxDriver(firefoxOptions),
                "pixel" => CreateChromeDriver("Pixel 2"),
                "iphone" => CreateChromeDriver("iPhone X"),
                "galaxy" => CreateChromeDriver("Galaxy S5"),
                _ => throw new ArgumentException($"Browser '{browser}' is not supported."),
            };
            Driver.Manage().Window.Maximize();
        }

        private static IWebDriver CreateChromeDriver(string deviceName)
        {
            chromeOptions.EnableMobileEmulation(deviceName);
           
            return new ChromeDriver(chromeOptions);
        }

        public static void QuitDriver()
        {
            Driver?.Quit();
        }
    }
}
