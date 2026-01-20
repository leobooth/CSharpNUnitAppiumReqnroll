using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework;

public static class ExtensionMethods
{
    public static bool IsVisible(this AppiumDriver driver, By byLocator)
    {
        try
        {
            AppiumElement element = driver.FindElement(byLocator);
            bool isEnabled = element.Enabled;
            bool isDisplayed = element.Displayed;
            bool isAreaGreaterThanZero = element.Rect.Height > 0 && element.Rect.Width > 0;
            return isEnabled && isDisplayed && isAreaGreaterThanZero;
        }
        catch (NotFoundException)
        {
            return false;
        }
    }
}