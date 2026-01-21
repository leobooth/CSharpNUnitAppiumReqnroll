using CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;
using CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Common;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium.Appium;
using Reqnroll;

namespace CSharpNUnitAppiumReqnroll.TestSuite._2_TestSteps.SauceLabs;

[Binding]
public class LoginSteps
{
    private ScenarioContext _scenarioContext;
    private AppiumDriver _driver;

    private ScreenHeader _screenHeader;
    private SidebarMenu _sidebarMenu;
    
    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (AppiumDriver)_scenarioContext["driver"];
        _screenHeader = new ScreenHeader(_driver);
        _sidebarMenu = new SidebarMenu(_driver);
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
        WaitUntil.ElementVisible(_driver, _screenHeader.MenuButton);
        _screenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, _sidebarMenu.LogInButton);
        _sidebarMenu.ClickLogInButton();
        
        WaitUntil.ElementVisible(_driver, loginScreen.UsernameTextbox);
        WaitUntil.ElementVisible(_driver, loginScreen.PasswordTextbox);
        loginScreen.Login(username, password);
    }
    
    [StepDefinition("I log out")]
    public void Logout()
    {
        LogoutAlert logoutAlert = new LogoutAlert(_driver);

        WaitUntil.ElementVisible(_driver, _screenHeader.MenuButton);
        _screenHeader.ClickMenuButton();
        
        WaitUntil.ElementVisible(_driver, _sidebarMenu.LogOutButton);
        _sidebarMenu.ClickLogOutButton();
        
        WaitUntil.ElementVisible(_driver, logoutAlert.LogoutButton);
        logoutAlert.ClickLogoutButton();
    }
}