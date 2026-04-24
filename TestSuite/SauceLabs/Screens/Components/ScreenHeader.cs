using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;

public class ScreenHeader : BaseScreen
{
    public ScreenHeader(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    
    public string ScreenContainer = "com.saucelabs.mydemoapp.android:id/header";
    
    public string AppLogo = "com.saucelabs.mydemoapp.android:id/mTvTitle";

    public string MenuButton = "com.saucelabs.mydemoapp.android:id/menuIV";
    
    public string CartButton = "com.saucelabs.mydemoapp.android:id/cartIV";

    public void ClickMenuButton()
    {
        Driver.FindElement(MobileBy.Id(MenuButton)).Click();
    }

    public void ClickCartButton()
    {
        Driver.FindElement(MobileBy.Id(CartButton)).Click();
    }
    
}