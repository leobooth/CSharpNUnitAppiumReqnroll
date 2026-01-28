namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class ConfigModels
{
    public class AppiumDevices
    {
        public List<DeviceOptions> Devices { get; set; }
    }

    public class DeviceOptions
    {
        public string AutomationName { get; set; }
        public string DeviceName { get; set; }
        public string PlatformVersion { get; set; }
        public string Udid { get; set; }
    }
}