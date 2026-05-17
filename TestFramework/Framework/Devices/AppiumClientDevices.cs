using System.Text.Json;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;

public class AppiumClientDevices
{
    public Dictionary<string, AppiumClientDevice> Devices { get; set; } = new();
    
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
    
    public static Dictionary<string, AppiumClientDevice> GetAppiumClientDevicesByDeviceId(string devicesJsonFilepath)
    {
        Dictionary<string, AppiumClientDevice> appiumClientDevicesByDeviceId = new Dictionary<string, AppiumClientDevice>();
        AppiumClientDevices appiumClientDevices = GetAppiumClientDevicesFromDevicesJson(devicesJsonFilepath);

        foreach (AppiumClientDevice device in appiumClientDevices.Devices.Values)
        {
            if (!string.IsNullOrEmpty(device.Avd))
            {
                appiumClientDevicesByDeviceId.Add(device.Avd, device);
            }
            else if (!string.IsNullOrEmpty(device.Udid))
            {
                appiumClientDevicesByDeviceId.Add(device.Udid, device);
            }
            else
            {
                throw new JsonException($"Unable to determine if Android device is an emulator or real device based on JSON properties. \n _" +
                                        $"Device must have either an 'avd' property (emulator) or 'udid' property (real device).");
            }
        }

        return appiumClientDevicesByDeviceId;
    }

    public static AppiumOptions CreateAppiumOptionsForAndroidEmulator(AppiumClientDevice device)
    {
        AppiumOptions appiumOptions = new AppiumOptions
        {
            PlatformName = device.PlatformName,
            PlatformVersion = device.PlatformVersion,
            AutomationName = device.AutomationName,
            DeviceName = device.DeviceName
        };
        appiumOptions.AddAdditionalAppiumOption("avd", device.Avd);
        appiumOptions.AddAdditionalAppiumOption("appPackage", device.AppPackage);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", device.EventTimings);
        appiumOptions.AddAdditionalAppiumOption("noReset", device.NoReset);
        
        return appiumOptions;
    }

    public static AppiumOptions CreateAppiumOptionsForAndroidRealDevice(AppiumClientDevice device)
    {
        AppiumOptions appiumOptions = new AppiumOptions
        {
            PlatformName = device.PlatformName,
            PlatformVersion = device.PlatformVersion,
            AutomationName = device.AutomationName,
            DeviceName = device.DeviceName
        };
        appiumOptions.AddAdditionalAppiumOption("udid", device.Udid);
        appiumOptions.AddAdditionalAppiumOption("appPackage", device.AppPackage);
        appiumOptions.AddAdditionalAppiumOption("eventTimings", device.EventTimings);
        appiumOptions.AddAdditionalAppiumOption("noReset", device.NoReset);
        
        return appiumOptions;
    }
}