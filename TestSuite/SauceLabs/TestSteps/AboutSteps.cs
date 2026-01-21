using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

[Binding]
public class AboutSteps
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;
    
    public AboutSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
    }

    [StepDefinition("the About screen is visible")]
    public void AboutScreenIsVisible()
    {
        AboutScreen aboutScreen = new AboutScreen(_driver);
        Assert.That(aboutScreen.IsVisible(), "About screen is not visible");
    }

    [StepDefinition("the version number is {string}")]
    public void VersionNumberMatches(string expectedVersionNumber)
    {
        AboutScreen aboutScreen = new AboutScreen(_driver);
        string actualVersionNumber = aboutScreen.GetAppVersionNumber();
        Assert.That(actualVersionNumber.Equals(expectedVersionNumber), 
            $"The actual version number '{actualVersionNumber}' does not match the expected version number '{expectedVersionNumber}'.");
    }
    
}