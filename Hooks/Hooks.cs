using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using NorthStandard.Utilities;
using OpenQA.Selenium;
using NorthStandard.Support;
using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks : ExtentReport
{
    private readonly IObjectContainer _container;
    private string _browser;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ExtentReportInit();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ExtentReportTearDown();
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }

    [BeforeScenario(tags: "@chrome", Order = 0)]
    public void ChromeBrowser()
    {
        _browser = "chrome";
    }

    [BeforeScenario(tags: "@firefox", Order = 0)]
    public void FirefoxBrowser()
    {
        _browser = "firefox";
    }

    [BeforeScenario(tags: "@pixel", Order = 0)]
    public void PixelBrowser()
    {
        _browser = "pixel";
    }

    [BeforeScenario(tags: "@iphone", Order = 0)]
    public void IphoneBrowser()
    {
        _browser = "iphone";
    }

    [BeforeScenario(tags: "@galaxy", Order = 0)]
    public void GalaxyBrowser()
    {
        _browser = "galaxy";
    }

    [BeforeScenario(Order = 1)]
    public void FirstBeforeScenario(ScenarioContext scenarioContext)
    {
        _browser ??= ConfigReader.GetAppSettings().Browser;
        DriverManager.InitializeDriver(_browser);
        _container.RegisterInstanceAs(DriverManager.Driver);
        _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext scenarioContext)
    {
        var driver = _container.Resolve<IWebDriver>();

        if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
        {
            _scenario.Fail(scenarioContext.TestError.Message,
                MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
        }
        else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
        {
            _scenario.Pass("This scenario Passed.");
        }
        else
        {
            _scenario.Skip("This scenario Passed.");
        }

        driver?.Quit();
    }

    [AfterStep]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        string stepName = scenarioContext.StepContext.StepInfo.Text;

        var driver = _container.Resolve<IWebDriver>();

        if (scenarioContext.TestError == null && scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.Skipped)
        {
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepName);
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepName);
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepName);
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepName);
            }
            else if (stepType == "But")
            {
                _scenario.CreateNode<But>(stepName);
            }
        }
        else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.Skipped)
        {
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepName).Skip("This step was skipped.");
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepName).Skip("This step was skipped.");
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepName).Skip("This step was skipped.");
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepName).Skip("This step was skipped.");
            }
            else if (stepType == "But")
            {
                _scenario.CreateNode<But>(stepName).Skip("This step was skipped.");
            }
        }
        else if (scenarioContext.TestError != null)
        {
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
            }
            else if (stepType == "But")
            {
                _scenario.CreateNode<But>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
            }
        };
    }

    public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
    {
        ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
        Screenshot screenshot = takesScreenshot.GetScreenshot();
        string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
        screenshot.SaveAsFile(screenshotLocation);
        return screenshotLocation;
    }
}
