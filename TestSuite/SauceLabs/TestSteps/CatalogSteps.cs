using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

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
        WaitUntil.ElementVisible(_driver, catalogScreen.ScreenContainer);
        Assert.That(catalogScreen.IsVisible(), "The Sauce Labs catalog screen is not visible");
    }
}