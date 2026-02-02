using CSharpNUnitAppiumReqnroll.TestFramework.Framework;
using CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestSuite.SauceLabs.Screens.SauceLabs;

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
    
    public string ScreenContainer = "com.saucelabs.mydemoapp.android:id/fragment_container";
    
    public string Title = "com.saucelabs.mydemoapp.android:id/productTV";

    // Products display
    public string ProductContainer = "com.saucelabs.mydemoapp.android:id/scrollView";

    public bool IsVisible()
    {
        bool isTitleVisible = Driver.IsVisible(MobileBy.Id(Title));
        bool isProductContainerVisible = Driver.IsVisible(MobileBy.Id(ProductContainer));
        return isTitleVisible && isProductContainerVisible;
    }
}