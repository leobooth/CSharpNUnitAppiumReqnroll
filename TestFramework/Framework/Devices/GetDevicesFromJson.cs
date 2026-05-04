using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetEnv;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;

public class AppiumClientDevices
{
    public Dictionary<string, AppiumClientDevice> Devices { get; set; } = new();
}

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

    [JsonPropertyName("apppium:noReset")] 
    public bool NoReset { get; set; } = false;
}

public class GetAppiumClientDevicesFromJson
{
    public static AppiumClientDevices GetAppiumClientDevicesFromDevicesJson(string devicesJsonFilepath)
    {
        String jsonString = File.ReadAllText(devicesJsonFilepath);
        AppiumClientDevices? appiumClientDevices = JsonSerializer.Deserialize<AppiumClientDevices>(jsonString);
        if (appiumClientDevices == null || appiumClientDevices.Devices.Count == 0)
        {
            throw new Exception($"No Appium client devices found in JSON file: {devicesJsonFilepath}");
        }
    
        return appiumClientDevices;
    }

    public static AppiumOptions CreateAppiumOptionsForAndroidEmulator(AppiumClientDevice device)
    {
        AppiumOptions appiumOptions = new AppiumOptions();
        appiumOptions.PlatformName = device.PlatformName;
        appiumOptions.PlatformVersion = device.PlatformVersion;
        appiumOptions.AutomationName = device.AutomationName;
        appiumOptions.DeviceName = device.DeviceName;
        appiumOptions.AddAdditionalAppiumOption("avd", device.Avd);
        appiumOptions.AddAdditionalAppiumOption("appPackage", device.AppPackage);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", device.EventTimings);
        appiumOptions.AddAdditionalAppiumOption("noReset", device.NoReset);
        
        return appiumOptions;
    }
    
    public static AppiumOptions CreateAppiumOptionsForAndroidRealDevice(AppiumClientDevice device)
    {
        AppiumOptions appiumOptions = new AppiumOptions();
        appiumOptions.PlatformName = device.PlatformName;
        appiumOptions.PlatformVersion = device.PlatformVersion;
        appiumOptions.AutomationName = device.AutomationName;
        appiumOptions.DeviceName = device.DeviceName;
        appiumOptions.AddAdditionalAppiumOption("appPackage", device.AppPackage);
        appiumOptions.AddAdditionalAppiumOption("udid", device.Udid);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", device.EventTimings);
        appiumOptions.AddAdditionalAppiumOption("noReset", device.NoReset);
        
        return appiumOptions;
    }

    public static Dictionary<string, AppiumOptions> GetAppiumOptionsByDeviceAvdOrUdid(string devicesJsonFilepath)
    {
        Dictionary<string, AppiumOptions> appiumOptionsByDeviceUdid = new();
        AppiumClientDevices appiumClientDevices = GetAppiumClientDevicesFromDevicesJson(devicesJsonFilepath);
        
        foreach(AppiumClientDevice device in appiumClientDevices.Devices.Values)
        {
            if (device.PlatformName.Equals("Android", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(device.Avd))
                {
                    AppiumOptions appiumOptions = CreateAppiumOptionsForAndroidEmulator(device);
                    appiumOptionsByDeviceUdid[device.Avd] = appiumOptions;
                }
                else if (!string.IsNullOrEmpty(device.Udid))
                {
                    AppiumOptions appiumOptions = CreateAppiumOptionsForAndroidRealDevice(device);
                    appiumOptionsByDeviceUdid[device.Udid] = appiumOptions;
                }
                else
                {
                    throw new JsonException($"Unable to determine if Android device is an emulator or real device based on JSON properties. \n _" +
                                            $"Device must have either an 'avd' property (emulator) or 'udid' property (real device). Device JSON: {JsonSerializer.Serialize(device)}");
                }
            }

            if (device.PlatformName.Equals("iOS", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotImplementedException("iOS device support not yet implemented.");
            }
        }
        
        return appiumOptionsByDeviceUdid;
    }
    
    
}


