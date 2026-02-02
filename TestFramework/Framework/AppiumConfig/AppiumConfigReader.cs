namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Models;

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DotNetEnv;
using OpenQA.Selenium;

public class AppiumConfigReader
{
    private readonly IConfiguration _configuration;

    public AppiumConfigReader()
    {
        Env.Load();
        string devicesJsonPath =
            "C:\\Users\\leobo\\Documents\\GithubProjects\\CSharpNUnitAppiumReqnroll\\TestSuite\\devices.json";
        
        // Set up the builder to read from devices.json
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(devicesJsonPath, optional: false, reloadOnChange: true)
            .Build();
    }

    public AppiumOptions GetDeviceOptions(string deviceName)
    {
        // Access the specific device section: "Devices:Emulator"
        var section = _configuration.GetSection($"Devices:{deviceName}");
        
        // Bind the section to a dictionary
        var caps = section.Get<Dictionary<string, object>>();

        if (caps == null)
            throw new NoNullAllowedException($"GetDeviceOptions did not find any options.");

        var options = new AppiumOptions();

        foreach (var cap in caps)
        {
            switch (cap.Key)
            {
                // handle options that do not use "appium:" prefix first
                case "platformName":
                    options.PlatformName = cap.Value.ToString();
                    break;
                
                case "automationName":
                    options.AutomationName = cap.Value.ToString();
                    break;
                
                case "deviceName":
                    options.DeviceName = cap.Value.ToString();
                    break;
                
                default:
                    try
                    {
                        string appiumOption = cap.Key.Replace("appium_", "");
                        var optionValue = cap.Value;
                        if (optionValue.ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                        {
                            optionValue = true;
                        } 
                        else if (optionValue.ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                        {
                            optionValue = false;
                        }
                        
                        options.AddAdditionalAppiumOption(appiumOption, optionValue);
                        break;
                    }
                    catch
                    {
                        throw new NotFoundException($"Invalid capability: {cap.Key}");
                    }
            }
        }

        return options;
    }
}