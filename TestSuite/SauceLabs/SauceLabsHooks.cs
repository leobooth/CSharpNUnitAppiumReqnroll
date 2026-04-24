using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
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
public class TestHooksSauceLabs
{   
    [BeforeFeature("@SauceLabs")]
    public void BeforeFeature()
    {
    }

    [BeforeScenario("@SauceLabs")]
    public void BeforeScenario()
    {
    }

    [AfterScenario("@SauceLabs")]
    public void AfterScenario()
    {
    }

    [AfterFeature("@SauceLabs")]
    public void AfterFeature()
    {
    }
}