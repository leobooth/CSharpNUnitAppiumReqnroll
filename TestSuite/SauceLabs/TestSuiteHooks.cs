using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using DotNetEnv;
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
        string envFilePath = "C:\\Users\\leobo\\Documents\\GithubProjects\\CSharpNUnitAppiumReqnroll\\TestSuite\\.env";
        DotNetEnv.Env.Load(envFilePath);
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
        string serverUri = Env.GetString("APPIUM_SERVER_URI");
        var driver = DriverFactory.CreateDriver(serverUri,"Emulator");
        DriverFactory.StoreDriverInScenarioContext(_scenarioContext, driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (_scenarioContext.ContainsKey("driver"))
        {
            AppiumDriver driver = (AppiumDriver)_scenarioContext["driver"];
            driver?.Quit();
        }
    }
}