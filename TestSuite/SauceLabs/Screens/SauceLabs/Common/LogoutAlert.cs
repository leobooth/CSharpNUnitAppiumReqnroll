using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Common;

public class LogoutAlert : BaseScreen
{
    
    public LogoutAlert(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    
    public By AlertContainer = By.XPath("//android.widget.FrameLayout[@resource-id=\"com.saucelabs.mydemoapp.android:id/action_bar_root\"]");
    public By Title = By.XPath("//android.widget.TextView[@resource-id=\"android:id/alertTitle\"][@text=\"Log Out\"]");
    public By Message = By.XPath("//android.widget.TextView[@resource-id=\"android:id/message\"]");
    public By LogoutButton = By.XPath("//android.widget.Button[@resource-id=\"android:id/button1\"][@text=\"LOGOUT\"]");
    public By CancelButton = By.XPath("//android.widget.Button[@resource-id=\"android:id/button2\"][@text=\"CANCEL\"]");

    public bool IsVisible()
    {
        bool isTitleVisible = Driver.FindElement(Title).Displayed;
        bool isLogoutButtonVisible = Driver.FindElement(LogoutButton).Displayed;
        
        return isTitleVisible && isLogoutButtonVisible;
    }

    public void ClickLogoutButton()
    {
        Driver.FindElement(LogoutButton).Click();
    }
}