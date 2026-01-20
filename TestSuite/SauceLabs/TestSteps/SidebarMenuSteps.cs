using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

[Binding]
public class SidebarMenuSteps
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;
    

    public SidebarMenuSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
    }

    [StepDefinition("I click the Catalog button")]
    public void ClickCatalogButton()
    {
        SidebarMenu sidebarMenu = new SidebarMenu(_driver);
        WaitUntil.ElementVisible(_driver, sidebarMenu.CatalogButton);
        _driver.FindElement(sidebarMenu.CatalogButton).Click();
    }
}