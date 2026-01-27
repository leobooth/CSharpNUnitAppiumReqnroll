using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite;

[Binding]
public class TestSuiteHooks
{
    private ScenarioContext _scenarioContext;
    
    public TestSuiteHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    /*
     * [BeforeTestRun]
     * [BeforeFeature]
     * [BeforeScenario]
     * [BeforeScenarioBlock]
     * [BeforeStep]
     * [AfterStep]
     * [AfterScenarioBlock]
     * [AfterScenario]
     * [AfterFeature]
     * [AfterTestRun]
     */
    
    [BeforeScenario]
    public void BeforeScenario()
    {
        var driver = DriverFactory.CreateDriver("ANDROID");
        DriverFactory.StoreDriverInScenarioContext(_scenarioContext, driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        AppiumDriver driver = (AppiumDriver)_scenarioContext["driver"];
        driver?.Quit();
    }
}