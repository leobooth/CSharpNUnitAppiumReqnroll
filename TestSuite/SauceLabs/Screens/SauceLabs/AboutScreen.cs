using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;

public class AboutScreen : BaseScreen
{
    AppiumDriver _driver;
    
    public AboutScreen(AppiumDriver driver)
    {
        _driver = driver;
    }

    public By Title = MobileBy.Id("com.saucelabs.mydemoapp.android:id/aboutTV");
    public By Logo1 = MobileBy.Id("com.saucelabs.mydemoapp.android:id/titleIV");
    public By AppVersionNumber = MobileBy.Id("com.saucelabs.mydemoapp.android:id/versionTV");
    public By Logo2 = MobileBy.Id("com.saucelabs.mydemoapp.android:id/teamIV");
    public By SauceLabsWebsiteLink = MobileBy.Id("com.saucelabs.mydemoapp.android:id/webTV");

    public bool IsVisible()
    {
        return _driver.IsVisible(Title);
    }

    public string GetAppVersionNumber()
    {
        return _driver.FindElement(AppVersionNumber).Text;
    }

    public void ClickSauceLabsWebsiteLink()
    {
        _driver.FindElement(SauceLabsWebsiteLink).Click();
    }
}