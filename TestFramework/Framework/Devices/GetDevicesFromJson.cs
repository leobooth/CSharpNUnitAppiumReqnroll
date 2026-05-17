using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetEnv;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;

// https://github.com/appium/appium-uiautomator2-driver#capabilities
public class AppiumClientDevice
{
    [JsonPropertyName("platformName")]
    public string PlatformName { get; set; } = "Android";
    
    [JsonPropertyName("platformVersion")]
    public string PlatformVersion { get; set; } = "16";

    [JsonPropertyName("appium:automationName")]
    public string AutomationName { get; set; } = "UiAutomator2";

    [JsonPropertyName("appium:deviceName")]
    public string DeviceName { get; set; } = string.Empty;
    
    [JsonPropertyName("appium:appPackage")]
    public string AppPackage { get; set; } = string.Empty;

    [JsonPropertyName("appium:udid")]
    public string Udid { get; set; } = string.Empty;
    
    [JsonPropertyName("appium:avd")]
    public string Avd { get; set; } = string.Empty;

    [JsonPropertyName("appium:eventTimings")] 
    public bool EventTimings { get; set; } = false;

    [JsonPropertyName("appium:noReset")] 
    public bool NoReset { get; set; } = false;
}

