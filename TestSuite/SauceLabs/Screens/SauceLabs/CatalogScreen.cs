using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite._3_Screens;

public class CatalogScreen : BaseScreen
{
    public ScreenHeader ScreenHeader;
    public SidebarMenu SidebarMenu;

    public CatalogScreen(AppiumDriver driver)
    {
        this.Driver = driver;
        this.ScreenHeader = new ScreenHeader(Driver);
        this.SidebarMenu = new SidebarMenu(Driver);
    }
    
    public By ScreenContainer = MobileBy.Id("com.saucelabs.mydemoapp.android:id/fragment_container");
    
    public By Title = MobileBy.Id("com.saucelabs.mydemoapp.android:id/productTV");

    // Products display
    public By ProductContainer = MobileBy.Id("com.saucelabs.mydemoapp.android:id/scrollView");

    public bool IsVisible()
    {
        bool isTitleVisible = Driver.IsVisible(Title);
        bool isProductContainerVisible = Driver.IsVisible(ProductContainer);
        return isTitleVisible && isProductContainerVisible;
    }
}