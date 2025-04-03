using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.PageObject;

public abstract class BasePage(IWebDriver driver)
{
    protected readonly IWebDriver driver = driver;
    protected readonly WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));
    private readonly string _authUrl = "SignIn";
    private readonly string _errorFrameId = "webpack-dev-server-client-overlay";
    private readonly string _errorXPath = "//*[text() = 'ERROR']";
    private readonly string _homePageLinkXPath = "//a[@data-testid='home-page-link']";
    private readonly string _loginButtonXPath = "//button[@data-testid='login-button']";
    private readonly string _basketButtonXPath = "//a[@data-testid='basket-button']";
    private readonly string _orderLogButtonXPath = "//a[@data-testid='order-button']";
    private readonly string _orderHistoryUrl = "Order";

    public void WaitForUrlToContain(string currentUrlPart)
    {
        wait.Until(d => d.Url.Contains(currentUrlPart));
    }

    public void WaitForElementVisible(By by)
    {
        wait.Until(d => d.FindElement(by).Displayed);
    }

    public void WaitForNewWindowAndSwitch()
    {
        wait.Until(d => d.WindowHandles.Count > 1);
        var newWindowHandle = driver.WindowHandles.Last();
        driver.SwitchTo().Window(newWindowHandle);
    }

    public void SwitchToFrame(string frameId)
    {
        wait.Until(d => d.FindElement(By.Id(frameId)).Displayed);
        driver.SwitchTo().Frame(frameId);
    }

    public bool IsElementDisplayed(By by)
    {
        try
        {
            var element = wait.Until(d => d.FindElement(by));
            return element.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void SendKeysToElement(string elementId, string value)
    {
        var element = wait.Until(d => d.FindElement(By.Id(elementId)));
        element.Clear();
        element.SendKeys(value);
    }

    public bool IsErrorFrameDisplayed()
    {
        try
        {
            WaitForElementVisible(By.Id(_errorFrameId));
            SwitchToFrame(_errorFrameId);
            return IsElementDisplayed(By.XPath(_errorXPath));
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    public void GoToHomePage()
    {
        driver.FindElement(By.XPath(_homePageLinkXPath)).Click();
    }

    public AuthPage GoToAuthPage()
    {
        driver.FindElement(By.XPath(_loginButtonXPath)).Click();
        WaitForUrlToContain(_authUrl);

        return new AuthPage(driver);
    }

    public BasketPage GoToBasketPage()
    {
        WaitForElementVisible(By.XPath(_basketButtonXPath));
        driver.FindElement(By.XPath(_basketButtonXPath)).Click();
        WaitForUrlToContain(BasketPage.BasketUrl);

        return new BasketPage(driver);
    }

    public void GoToOrderLog()
    {
        driver.FindElement(By.XPath(_orderLogButtonXPath)).Click();
        WaitForUrlToContain(_orderHistoryUrl);
    }
}
