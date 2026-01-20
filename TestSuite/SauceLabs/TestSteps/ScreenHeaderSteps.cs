using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

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

    [StepDefinition("I click the Menu button")]
    public void ClickMenuButton()
    {
        ScreenHeader screenHeader = new ScreenHeader(_driver);
        WaitUntil.ElementVisible(_driver, screenHeader.MenuButton);
        screenHeader.ClickMenuButton();
    }
}