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
        DriverHelper.StoreDriverInScenarioContext(_scenarioContext);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        AppiumDriver driver = (AppiumDriver)_scenarioContext["driver"];
        driver.Quit();
    }
}