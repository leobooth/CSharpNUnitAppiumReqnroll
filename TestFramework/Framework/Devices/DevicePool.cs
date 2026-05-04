using System.Collections.Concurrent;
using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Devices;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class DevicePool
{
    private static ConcurrentDictionary<string, bool> _CheckoutStatusByDeviceAvdOrUdid;
    private static ConcurrentDictionary<string, AppiumOptions> _AppiumOptionsByDeviceAvdOrUdid;
    
    public DevicePool(string devicesJsonFilepath)
    {
        Dictionary<string, AppiumOptions> appiumOptionsByDevice =
            GetAppiumClientDevicesFromJson.GetAppiumOptionsByDeviceAvdOrUdid(devicesJsonFilepath);
        _CheckoutStatusByDeviceAvdOrUdid = new ConcurrentDictionary<string, bool>();
        _AppiumOptionsByDeviceAvdOrUdid = new ConcurrentDictionary<string, AppiumOptions>();

        foreach (string deviceAvdOrUdid in appiumOptionsByDevice.Keys)
        {
            _CheckoutStatusByDeviceAvdOrUdid.TryAdd(deviceAvdOrUdid, false);
            _AppiumOptionsByDeviceAvdOrUdid.TryAdd(deviceAvdOrUdid, appiumOptionsByDevice[deviceAvdOrUdid]);
        }
    } 

    public static List<AppiumOptions> GetDevices => _AppiumOptionsByDeviceAvdOrUdid.Values.ToList();
    
    // TODO: create functions to check out devices by OS, emulator or real device
    //       use LINQ to filter for available devices
    
    public static AppiumOptions CheckoutDevice(string deviceAvdOrUdid)
    {
        _CheckoutStatusByDeviceAvdOrUdid[deviceAvdOrUdid] = true;
        return _AppiumOptionsByDeviceAvdOrUdid[deviceAvdOrUdid];
    }

    public static void ReturnDevice(string deviceAvdOrUdid)
    {
        _CheckoutStatusByDeviceAvdOrUdid[deviceAvdOrUdid] = false;
    }
}