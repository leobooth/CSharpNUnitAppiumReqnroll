using System.Collections.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;

public enum DeviceType
{
    EMULATOR,
    REAL_DEVICE
}

public enum PlatformName
{
    ANDROID,
    IOS,
    WEB
}

public enum AutomationName
{
    UIAUTOMATOR2,
    XCUITEST,
    WINAPPDRIVER
}

public class Device
{
    public DeviceType DeviceType { get; set; }
    public required string DeviceSerialNumber { get; set; }
    public PlatformName PlatformName { get; set; }
    public string PlatformVersion { get; set; }
    public AutomationName AutomationName { get; set; }
    public string DeviceName { get; set; }
    public string AppPackage { get; set; }
    public string Udid { get; set; }
    public string Avd { get; set; }
    public bool EventTimings { get; set; }
    public bool NoReset { get; set; }
}

public class DevicePool
{
    private static ConcurrentDictionary<string, bool> _checkoutStatusByDeviceAvdOrUdid = new ConcurrentDictionary<string, bool>();
    private static ConcurrentDictionary<string, AppiumClientDevice> _appiumClientDeviceByAvdOrUdid = new ConcurrentDictionary<string, AppiumClientDevice>();
    
    public DevicePool(string devicesJsonFilepath)
    {
        Dictionary<string, AppiumClientDevice> appiumClientDevicesByDeviceId =
            AppiumClientDevices.GetAppiumClientDevicesByDeviceId(devicesJsonFilepath);
        _appiumClientDeviceByAvdOrUdid = new ConcurrentDictionary<string, AppiumClientDevice>(appiumClientDevicesByDeviceId);
        _checkoutStatusByDeviceAvdOrUdid = new ConcurrentDictionary<string, bool>();

        foreach(var deviceAvdOrUdid in appiumClientDevicesByDeviceId.Keys)
        {
            _checkoutStatusByDeviceAvdOrUdid.TryAdd(deviceAvdOrUdid, false);
        }
    } 

    public static List<string> GetDeviceIds => _appiumClientDeviceByAvdOrUdid.Keys.ToList();
    public static List<AppiumClientDevice> GetDevices => _appiumClientDeviceByAvdOrUdid.Values.ToList();
    
    public static AppiumClientDevice CheckoutDevice(string deviceAvdOrUdid)
    {
        _checkoutStatusByDeviceAvdOrUdid[deviceAvdOrUdid] = true;
        return _appiumClientDeviceByAvdOrUdid[deviceAvdOrUdid];
    }

    public static AppiumOptions CheckoutFirstAvailableDevice(PlatformName platformName, DeviceType deviceType)
    {
        foreach(string deviceId in _checkoutStatusByDeviceAvdOrUdid.Keys)
        {
            bool isDeviceCheckedOut = _checkoutStatusByDeviceAvdOrUdid[deviceId];
            if (!isDeviceCheckedOut)
            {
                AppiumClientDevice appiumClientDevice = _appiumClientDeviceByAvdOrUdid[deviceId];
                AppiumOptions appiumOptions = new AppiumOptions();
                
                bool isValidPlatformName = appiumClientDevice.PlatformName.Equals(platformName.ToString(), StringComparison.OrdinalIgnoreCase);
                bool isDeviceAnEmulator = !string.IsNullOrEmpty(appiumClientDevice.Avd);
                bool isDeviceARealDevice = !string.IsNullOrEmpty(appiumClientDevice.Udid);
                
                if (!isDeviceAnEmulator && !isDeviceARealDevice)
                {
                    throw new ArgumentException("Unable to determine if this device is an emulator or real device.");
                }
                
                bool isMatchingDeviceType = (deviceType == DeviceType.EMULATOR && isDeviceAnEmulator) || 
                                            (deviceType == DeviceType.REAL_DEVICE && isDeviceARealDevice);
                
                if (isValidPlatformName && isMatchingDeviceType)
                {
                    AppiumClientDevice firstAvailableDevice = CheckoutDevice(deviceId);
                }

                if (isMatchingDeviceType && deviceType == DeviceType.EMULATOR)
                {
                    Console.WriteLine($"{platformName} emulator with AVD: {appiumClientDevice.Avd} has been checked out."); 
                    appiumOptions = AppiumClientDevices.CreateAppiumOptionsForAndroidEmulator(appiumClientDevice);
                }
                else if (isMatchingDeviceType && deviceType == DeviceType.REAL_DEVICE)
                {
                    Console.WriteLine($"{platformName} device with UDID: {appiumClientDevice.Udid} has been checked out.");
                    appiumOptions = AppiumClientDevices.CreateAppiumOptionsForAndroidRealDevice(appiumClientDevice);
                }

                return appiumOptions;
            }
        }
        
        throw new WebDriverException($"No available devices found for platform: {platformName} and type: {deviceType}");
    }
    
    public static void ReturnDevice(string deviceAvdOrUdid)
    {
        _checkoutStatusByDeviceAvdOrUdid[deviceAvdOrUdid] = false;
    }
}