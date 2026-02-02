using System.Text.Json;
using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Models;
using System.Collections.Concurrent;
using DotNetEnv;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public class DevicePool
{
    private static ConcurrentQueue<DeviceOptions> _availableDevices;
    private static AppiumDevices _devices;
    private static string _devicesJsonPath = Env.GetString("DEVICES_JSON_PATH");
    
    static DevicePool()
    {
        using FileStream openStream = File.OpenRead(Env.GetString(_devicesJsonPath));
        _devices = JsonSerializer.Deserialize<AppiumDevices>(openStream);
        _availableDevices = new ConcurrentQueue<DeviceOptions>(_devices.Devices);
        Console.WriteLine(_availableDevices.Count);
    }

    public static AppiumDevices Devices => _devices;

    public static DeviceOptions GetDevice()
    {
        _availableDevices.TryDequeue(out var device);
        return device;
    }

    public static void ReturnDevice(DeviceOptions device)
    {
        _availableDevices.Enqueue(device);
    }
}