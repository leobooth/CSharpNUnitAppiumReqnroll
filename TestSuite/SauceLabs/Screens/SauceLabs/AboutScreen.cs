using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs;

public class AboutScreen : BaseScreen
{
    AppiumDriver _driver;
    
    public AboutScreen(AppiumDriver driver)
    {
        _driver = driver;
    }

    public string Title = "com.saucelabs.mydemoapp.android:id/aboutTV";
    public string Logo1 = "com.saucelabs.mydemoapp.android:id/titleIV";
    public string AppVersionNumber = "com.saucelabs.mydemoapp.android:id/versionTV";
    public string Logo2 = "com.saucelabs.mydemoapp.android:id/teamIV";
    public string SauceLabsWebsiteLink = "com.saucelabs.mydemoapp.android:id/webTV";

    public bool IsVisible()
    {
        return _driver.IsVisible(MobileBy.Id(Title));
    }

    public string GetAppVersionNumber()
    {
        return _driver.FindElement(MobileBy.Id(AppVersionNumber)).Text;
    }

    public void ClickSauceLabsWebsiteLink()
    {
        _driver.FindElement(MobileBy.Id(SauceLabsWebsiteLink)).Click();
    }
}