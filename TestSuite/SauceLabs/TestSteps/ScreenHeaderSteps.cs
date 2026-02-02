using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.TestSteps;

[Binding]
public class ScreenHeaderSteps
{
    ScenarioContext _scenarioContext;
    AppiumDriver _driver;

    public ScreenHeaderSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
    }

    [StepDefinition("I open the sidebar menu")]
    public void ClickMenuButton()
    {
        ScreenHeader screenHeader = new ScreenHeader(_driver);
        WaitUntil.ElementVisible(_driver, MobileBy.Id(screenHeader.MenuButton));
        screenHeader.ClickMenuButton();
    }
}