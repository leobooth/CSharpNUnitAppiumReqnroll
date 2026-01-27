using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using Reqnroll;
using DotNetEnv;
using OpenQA.Selenium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;



public class DriverFactory
{
    private static string _seleniumGridHubUrl = Env.GetString("SELENIUM_GRID_HUB_URL");
    
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
        if (appiumOptions.PlatformName.Equals("ANDROID", StringComparison.OrdinalIgnoreCase))
        {
            return new AndroidDriver(new Uri(_seleniumGridHubUrl), appiumOptions);
        }
        
        if (appiumOptions.PlatformName.Equals("IOS", StringComparison.OrdinalIgnoreCase))
        {
            return new AndroidDriver(new Uri(_seleniumGridHubUrl), appiumOptions);
        }
        
        // if (appiumOptions.PlatformName.Equals("WINDOWS", StringComparison.OrdinalIgnoreCase))
        // {
        //     return new WindowsDriver(new Uri(SELENIUM_GRID_HUB_URL), appiumOptions);
        // }

        throw new WebDriverException($"Unable to create Appium driver with platform name: {appiumOptions.PlatformName}");
    }
    
    public static AppiumDriver CreateDriver(string deviceName)
    {
        // TODO: use device name to create Appium options for that device
        AppiumOptions appiumOptions = CreateAppiumOptions();
        AppiumDriver appiumDriver = CreateAppiumDriver(appiumOptions);
        
        return appiumDriver;
    }
    
    public static void StoreDriverInScenarioContext(ScenarioContext scenarioContext, AppiumDriver appiumDriver)
    {
        scenarioContext["driver"] = appiumDriver;
    }
}