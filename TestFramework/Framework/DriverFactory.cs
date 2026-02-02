using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Reqnroll;
using DotNetEnv;
using OpenQA.Selenium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class DriverFactory
{
    private static AppiumOptions CreateAppiumOptions(string deviceName)
    {
        AppiumOptions appiumOptions = new AppiumOptions();
        
        // // TODO: populate appiumOptions from env and/or JSON files
        appiumOptions.PlatformName = "Android";
        appiumOptions.AutomationName = "UiAutomator2";
        appiumOptions.DeviceName = "API-36-1";
        appiumOptions.AddAdditionalAppiumOption("udid", "emulator-5554");
        // appiumOptions.AddAdditionalAppiumOption("appPackage", "com.saucelabs.mydemoapp.android");
        
        // NoReset assumes the app is preinstalled on the emulator
        appiumOptions.AddAdditionalAppiumOption("noReset", true);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", true);
        
        // AppiumConfigReader reader = new AppiumConfigReader();
        // appiumOptions = reader.GetDeviceOptions(deviceName);
        
        return appiumOptions;
    }
    
    private static AppiumDriver CreateAppiumDriver(string serverUri, AppiumOptions appiumOptions)
    {
        var platformName = appiumOptions.PlatformName ?? string.Empty;
        if (platformName.Equals("ANDROID", StringComparison.OrdinalIgnoreCase))
        {
            var appiumDriver = new AndroidDriver(new Uri(serverUri), appiumOptions, TimeSpan.FromSeconds(180));
            return appiumDriver;
        }
        
        // if (appiumOptions.PlatformName.Equals("IOS", StringComparison.OrdinalIgnoreCase))
        // {
        //     return new IOSDriver(new Uri(_seleniumGridHubUrl), appiumOptions);
        // }
        
        // if (appiumOptions.PlatformName.Equals("WINDOWS", StringComparison.OrdinalIgnoreCase))
        // {
        //     return new WindowsDriver(new Uri(SELENIUM_GRID_HUB_URL), appiumOptions);
        // }

        throw new WebDriverException($"Unable to create Appium driver with platform name: {appiumOptions.PlatformName}");
    }
    
    public static AppiumDriver CreateDriver(string serverUri, string deviceName)
    {
        
        AppiumOptions appiumOptions = CreateAppiumOptions(deviceName);
        AppiumDriver appiumDriver = CreateAppiumDriver(serverUri, appiumOptions);
        
        return appiumDriver;
    }
    
    public static void StoreDriverInScenarioContext(ScenarioContext scenarioContext, AppiumDriver appiumDriver)
    {
        scenarioContext["driver"] = appiumDriver;
    }
}