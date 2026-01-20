using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;

public class SidebarMenu : BaseScreen
{
    public SidebarMenu(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    
    public By MenuContainer = By.XPath("//android.view.ViewGroup[@resource-id='com.saucelabs.mydemoapp.android:id/drawerMenu']");
    
    // Menu buttons
    public By CatalogButton =
        By.XPath("//android.widget.TextView[@resource-id='com.saucelabs.mydemoapp.android:id/itemTV' and @text='Catalog']");
    public By LogInButton =
        By.XPath("//android.widget.TextView[@resource-id='com.saucelabs.mydemoapp.android:id/itemTV'][@text='Log In']");
    public By LogOutButton =
        By.XPath("//android.widget.TextView[@resource-id='com.saucelabs.mydemoapp.android:id/itemTV'][@text='Log Out']");

    public void ClickCatalogButton()
    {
        Driver.FindElement(CatalogButton).Click();
    }
    public void ClickLogInButton()
    {
        Driver.FindElement(LogInButton).Click();
    }
    
    public void ClickLogOutButton()
    {
        Driver.FindElement(LogOutButton).Click();
    }
}