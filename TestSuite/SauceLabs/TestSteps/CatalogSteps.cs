using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.TestSteps;

[Binding]
public class CatalogSteps : BaseScreen
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;
    
    public CatalogSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
    }

    [StepDefinition("the Catalog screen is visible")]
    public void CatalogScreenIsVisible()
    {
        CatalogScreen catalogScreen = new CatalogScreen(_driver);
        WaitUntil.ElementVisible(_driver, MobileBy.Id(catalogScreen.ScreenContainer));
        Assert.That(catalogScreen.IsVisible(), "The Sauce Labs catalog screen is not visible");
    }
}