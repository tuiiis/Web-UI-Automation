using OpenQA.Selenium;

namespace Tests.PageObject;

public class BasketPage(IWebDriver driver) : BasePage(driver)
{
    public const string BasketUrl = "Basket";
    public const string OrderUrl = "BuyBasket";
    private readonly string _basketItemXPath = "//div[@data-field='productName']//div[@class='MuiDataGrid-cellContent']";
    private readonly string _deleteButtonXPath = "//button[@data-testid='delete-button']";
    private readonly string _confirmButtonXPath = "//button[@data-testid='confirm-button']";
    private readonly string _orderButtonXPath = "//a[@data-testid='buy-basket-button']";

    public void EmptyBasket()
    {
        while (driver.FindElements(By.XPath(_deleteButtonXPath)).Count > 0)
        {
            WaitForElementVisible(By.XPath(_deleteButtonXPath));
            driver.FindElement(By.XPath(_deleteButtonXPath)).Click();
            WaitForElementVisible(By.XPath(_confirmButtonXPath));
            driver.FindElement(By.XPath(_confirmButtonXPath)).Click();
        }
    }

    public OrderPage GoToOrderPage()
    {
        driver.FindElement(By.XPath(_orderButtonXPath)).Click();
        WaitForUrlToContain(OrderUrl);

        return new OrderPage(driver);
    }

    public string BasketItemNameText()
    {
        WaitForElementVisible(By.XPath(_basketItemXPath));
        var basketItemName = driver.FindElement(By.XPath(_basketItemXPath)).Text;

        return basketItemName;
    }

    public bool IsRedirected()
    {
        return driver.Url.Contains(BasketUrl);
    }
}
