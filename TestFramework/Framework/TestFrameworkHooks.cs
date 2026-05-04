using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;
using DotNetEnv;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite;

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
// https://docs.reqnroll.net/latest/automation/hooks.html#supported-hook-attributes

[Binding]
public class TestFrameworkHooks
{
    private ScenarioContext _scenarioContext;
    
    public TestFrameworkHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        
        string envFilePath = "C:\\Users\\leobo\\Documents\\GithubProjects\\CSharpNUnitAppiumReqnroll\\TestSuite\\.env";
        Env.Load(envFilePath);
    }
    
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // Code to run before the entire test run starts
        string devicesJsonFilepath = Env.GetString("DEVICES_JSON_PATH");
        AppiumClientDevices devices = GetAppiumClientDevicesFromJson.GetAppiumClientDevicesFromDevicesJson(devicesJsonFilepath);
        Console.WriteLine("breakpoint");
    }
    
    [BeforeScenario]
    public void BeforeScenario()
    {

    }

    [AfterScenario]
    public void AfterScenario()
    {
        
    }
}