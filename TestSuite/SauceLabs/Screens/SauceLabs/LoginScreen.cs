using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs;

public class LoginScreen : BaseScreen
{
    public LoginScreen(AppiumDriver driver)
    {
        this.Driver = driver;
    }
    
    public string ScreenContainer = "com.saucelabs.mydemoapp.android:id/fragment_container";

    public string Title = "com.saucelabs.mydemoapp.android:id/loginTV";

    public string LoginInstructions = "com.saucelabs.mydemoapp.android:id/selectTextTV";

    public string UsernameTextbox = "com.saucelabs.mydemoapp.android:id/nameET";

    public string PasswordTextbox = "com.saucelabs.mydemoapp.android:id/passwordET";

    public string PasswordErrorMessage = "com.saucelabs.mydemoapp.android:id/passwordErrorTV";
    
    public string LoginButton = "com.saucelabs.mydemoapp.android:id/loginBtn";

    public void Login(string username, string password)
    {
        Driver.FindElement(MobileBy.Id(UsernameTextbox)).SendKeys(username);
        Driver.FindElement(MobileBy.Id(PasswordTextbox)).SendKeys(password);
        Driver.FindElement(MobileBy.Id(LoginButton)).Click();
    }

    public bool IsVisible()
    {
        bool isTitleVisible = Driver.IsVisible(MobileBy.Id(Title));
        bool isLoginButtonVisible = Driver.IsVisible(MobileBy.Id(LoginInstructions));
        return isTitleVisible && isLoginButtonVisible;
    }
}