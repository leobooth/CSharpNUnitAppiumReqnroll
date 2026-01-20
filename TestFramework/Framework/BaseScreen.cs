using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class BaseScreen
{
    protected AppiumDriver Driver;

    public BaseScreen() { }
    
    public BaseScreen(AppiumDriver driver)
    {
        this.Driver = driver;
    }
}