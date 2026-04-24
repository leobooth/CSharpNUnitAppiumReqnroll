public enum DeviceType
{
    EMULATOR,
    REAL_DEVICE
}

public enum Platform
{
    ANDROID,
    IOS,
    WEB,
    WINDOWS
}

public class Device
{
    public string Name { get; set; }
    public DeviceType DeviceType { get; set; }
    public Platform Platform { get; set; }
    public string OperatingSystemVersion { get; set; }
    public string Udid { get; set; }
}