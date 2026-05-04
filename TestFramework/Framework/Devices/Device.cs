public enum DeviceType
{
    EMULATOR,
    REAL_DEVICE
}

public enum PlatformName
{
    ANDROID,
    IOS,
    WEB,
    WINDOWS
}

public enum AutomationName
{
    UIAUTOMATOR2,
    XCUITEST
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