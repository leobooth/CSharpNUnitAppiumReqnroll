using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace CSharpNUnitAppiumReqnroll.TestFramework.Framework.Waits;

public class WaitUntil
{
    public static bool ElementVisible(AppiumDriver driver, By byLocator, int seconds = 30, int pollingIntervalInMillis = 500)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        wait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMillis);
        
        return wait.Until(drv =>
        {
            try
            {
                AppiumDriver appiumDriver = (AppiumDriver)drv;
                return appiumDriver.IsVisible(byLocator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }
    
    public static bool ElementAttributeMatches(AppiumDriver driver, By byLocator, string attributeName, string expectedValue, int seconds = 30, int pollingIntervalInMillis = 500)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        wait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMillis);
        
        return wait.Until(drv =>
        {
            try
            {
                AppiumElement element = (AppiumElement)drv.FindElement(byLocator);
                
                bool isAttributeValueVisible = false;
                try
                {
                    string attributeValue = element.GetAttribute(attributeName);
                    isAttributeValueVisible = attributeValue.Equals(expectedValue);

                }
                catch (NullReferenceException)
                {
                    isAttributeValueVisible = false;
                }
                
                return isAttributeValueVisible;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        });
    }
}