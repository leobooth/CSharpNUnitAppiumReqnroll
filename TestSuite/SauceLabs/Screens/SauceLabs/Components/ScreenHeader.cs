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
    
    public By ScreenContainer = MobileBy.Id("com.saucelabs.mydemoapp.android:id/header");
    
    public By AppLogo = MobileBy.Id("com.saucelabs.mydemoapp.android):id/mTvTitle");

    public By MenuButton = MobileBy.Id("com.saucelabs.mydemoapp.android:id/menuIV");
    
    public By CartButton = MobileBy.Id("com.saucelabs.mydemoapp.android:id/cartIV");

    public void ClickMenuButton()
    {
        Driver.FindElement(MenuButton).Click();
    }

    public void ClickCartButton()
    {
        Driver.FindElement(CartButton).Click();
    }
    
}