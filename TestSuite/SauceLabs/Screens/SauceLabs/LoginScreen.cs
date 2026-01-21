using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;

public class LoginScreen : BaseScreen
{
    public LoginScreen(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    
    public By ScreenContainer = MobileBy.Id("com.saucelabs.mydemoapp.android:id/fragment_container");

    public By Title = MobileBy.Id("com.saucelabs.mydemoapp.android:id/loginTV");

    public By LoginInstructions = MobileBy.Id("com.saucelabs.mydemoapp.android:id/selectTextTV");

    public By UsernameTextbox = MobileBy.Id("com.saucelabs.mydemoapp.android:id/nameET");

    public By PasswordTextbox = MobileBy.Id("com.saucelabs.mydemoapp.android:id/passwordET");

    public By LoginButton = MobileBy.Id("com.saucelabs.mydemoapp.android:id/loginBtn");

    public void Login(string username, string password)
    {
        Driver.FindElement(UsernameTextbox).SendKeys(username);
        Driver.FindElement(PasswordTextbox).SendKeys(password);
        Driver.FindElement(LoginButton).Click();
    }

    public bool IsVisible()
    {
        bool isTitleVisible = Driver.IsVisible(Title);
        bool isLoginButtonVisible = Driver.IsVisible(LoginInstructions);
        return isTitleVisible && isLoginButtonVisible;
    }
}