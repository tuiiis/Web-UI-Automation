using OpenQA.Selenium;

namespace Tests.PageObject;

public class HomePage(IWebDriver driver) : BasePage(driver)
{
    public const string DetailsUrl = "details";
    public readonly string AuthUrl = "SignIn";
    private readonly string _basketButtonXPath = "//a[@data-testid='basket-button']";
    private readonly string _addToBasketButtonXPath = "//button[@data-testid='add-to-basket-button']";
    private readonly string _url = "http://localhost:3000/";
    private readonly string _detailButtonXPath = "//button[@data-testid='detail-button']";
    private readonly string _plantNameXPath = "//div[@data-testid='plant-name']";

    public void Open()
    {
        driver.Navigate().GoToUrl(_url);
    }

    public bool IsLoggedIn()
    {
        WaitForElementVisible(By.XPath(_basketButtonXPath));
        return driver.FindElement(By.XPath(_basketButtonXPath)).Displayed;
    }

    public string AddItemToBasket()
    {
        var plantElement = driver.FindElement(By.XPath(_plantNameXPath));

        string plantName = plantElement.Text;

        plantElement.FindElement(By.XPath(_addToBasketButtonXPath)).Click();

        return plantName;
    }

    public (DetailsPage, string) GoToProductDetails()
    {
        var plantButton = driver.FindElement(By.XPath(_detailButtonXPath));

        string plantName = plantButton.FindElement(By.XPath(_plantNameXPath)).Text;

        plantButton.Click();

        WaitForNewWindowAndSwitch();

        WaitForUrlToContain(DetailsUrl);

        return (new DetailsPage(driver), plantName);
    }

    public void WaitUntilIsRedirected()
    {
        wait.Until(_ => IsElementDisplayed(By.XPath(_addToBasketButtonXPath)));
    }


}
