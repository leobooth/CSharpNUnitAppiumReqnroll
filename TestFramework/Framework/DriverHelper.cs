using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class DriverHelper
{
    private static AppiumOptions CreateAppiumOptions()
    {
        AppiumOptions appiumOptions = new AppiumOptions();
        
        // TODO: populate appiumOptions from env and/or JSON files
        appiumOptions.PlatformName = "Android";
        appiumOptions.AutomationName = "UiAutomator2";
        appiumOptions.DeviceName = "Medium_Phone_API_36.1";
        appiumOptions.AddAdditionalAppiumOption("uuid", "emulator-5554");
        appiumOptions.AddAdditionalAppiumOption("appPackage", "com.saucelabs.mydemoapp.android");
        appiumOptions.AddAdditionalAppiumOption("noReset", true);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", true);
        
        return appiumOptions;
    }
    
    private static AppiumDriver CreateAppiumDriver(AppiumOptions appiumOptions)
    {
        if (appiumOptions.PlatformName.Equals("Android", StringComparison.OrdinalIgnoreCase))
        {
            return new AndroidDriver(appiumOptions);
        }
        
        if (appiumOptions.PlatformName.Equals("Windows", StringComparison.OrdinalIgnoreCase))
        {
            return new WindowsDriver(appiumOptions);
        }

        throw new WebDriverException($"Unable to create Appium driver with platform name: {appiumOptions.PlatformName}");
    }
    
    public static void StoreDriverInScenarioContext(ScenarioContext scenarioContext)
    {
        AppiumOptions appiumOptions = CreateAppiumOptions();
        AppiumDriver appiumDriver = CreateAppiumDriver(appiumOptions);
        scenarioContext["driver"] = appiumDriver;
    }
}