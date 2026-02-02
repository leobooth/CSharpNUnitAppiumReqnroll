using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Common;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium.Appium;
using Reqnroll;
using NUnit.Framework;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.TestSteps;

[Binding]
public class LoginSteps
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;

    private ScreenHeader _screenHeader;
    private SidebarMenu _sidebarMenu;
    private LoginScreen _loginScreen;
    private LogoutAlert _logoutAlert;

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
        _screenHeader = new ScreenHeader(_driver);
        _sidebarMenu = new SidebarMenu(_driver);
        _loginScreen = new LoginScreen(_driver);
        _logoutAlert = new LogoutAlert(_driver);
    }

    [StepDefinition("the Login screen is visible")]
    public void LoginScreenIsVisible()
    {
        Assert.That(_loginScreen.IsVisible(), "Login screen is not visible");
    }
    
    
    [StepDefinition("I log in as user {string} with password {string}")]
    public void LogInAsUser(string username, string password)
    {
        // TODO: extend Click() and other actions to wait for elements first
        WaitUntil.ElementVisible(_driver, MobileBy.Id(_screenHeader.MenuButton));
        _screenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, _sidebarMenu.LogInButton);
        _sidebarMenu.ClickLogInButton();
        
        WaitUntil.ElementVisible(_driver, MobileBy.Id(_loginScreen.UsernameTextbox));
        WaitUntil.ElementVisible(_driver, MobileBy.Id(_loginScreen.PasswordTextbox));
        _loginScreen.Login(username, password);
    }

    [StepDefinition("the Locked Out message is visible")]
    public void LockedOutMessageIsVisible()
    {
        WaitUntil.ElementVisible(_driver, MobileBy.Id(_loginScreen.PasswordErrorMessage));
    }
    
    [StepDefinition("I log out")]
    public void Logout()
    {
        WaitUntil.ElementVisible(_driver, MobileBy.Id(_screenHeader.MenuButton));
        _screenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, _sidebarMenu.LogOutButton);
        _sidebarMenu.ClickLogOutButton();
        
        WaitUntil.ElementVisible(_driver, _logoutAlert.LogoutButton);
        _logoutAlert.ClickLogoutButton();
    }
}