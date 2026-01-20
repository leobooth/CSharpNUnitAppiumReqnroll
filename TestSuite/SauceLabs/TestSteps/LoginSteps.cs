using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Common;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

[Binding]
public class LoginSteps
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;
    
    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
    }

    [StepDefinition("the Login screen is visible")]
    public void LoginScreenIsVisible()
    {
        LoginScreen loginScreen = new LoginScreen(_driver);
        Assert.That(loginScreen.IsVisible(), "Login screen is not visible");
    }
    
    
    [StepDefinition("I log in as user {string} with password {string}")]
    public void LogInAsUser(string username, string password)
    {
        LoginScreen loginScreen = new LoginScreen(_driver);
        
        // TODO: extend Click() and other actions to wait for elements first
        WaitUntil.ElementVisible(_driver, loginScreen.ScreenHeader.MenuButton);
        loginScreen.ScreenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, loginScreen.SidebarMenu.LogInButton);
        loginScreen.SidebarMenu.ClickLogInButton();
        
        WaitUntil.ElementVisible(_driver, loginScreen.UsernameTextbox);
        WaitUntil.ElementVisible(_driver, loginScreen.PasswordTextbox);
        loginScreen.Login(username, password);
    }
    
    [StepDefinition("I log out")]
    public void Logout()
    {
        LoginScreen loginScreen = new LoginScreen(_driver);
        LogoutAlert logoutAlert = new LogoutAlert(_driver);

        WaitUntil.ElementVisible(_driver, loginScreen.ScreenHeader.MenuButton);
        loginScreen.ScreenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, loginScreen.SidebarMenu.LogOutButton);
        loginScreen.SidebarMenu.ClickLogOutButton();
        
        WaitUntil.ElementVisible(_driver, logoutAlert.LogoutButton);
        logoutAlert.ClickLogoutButton();
    }
}