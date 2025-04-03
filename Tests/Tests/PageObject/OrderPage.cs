using OpenQA.Selenium;
using Tests.DataGenerator;
using Tests.Models;

namespace Tests.PageObject;

public class OrderPage(IWebDriver driver) : BasePage(driver)
{
    private static readonly string _orderLogAddress = "(//td[@data-testid='address-field'])[last()]";
    private static readonly string _alertMessageXPath = "//div[@role = 'alert']";

    private readonly string _nextButtonXPath = "//button[@data-testid='next-button']";

    public void ProceedToNextPage()
    {
        driver.FindElement(By.XPath(_nextButtonXPath)).Click();
        WaitForElementVisible(By.XPath(_nextButtonXPath));
    }

    public bool IsAlertDisplayed()
    {
        WaitForElementVisible(By.XPath(_alertMessageXPath));
        return IsElementDisplayed(By.XPath(_alertMessageXPath));
    }

    public string OrderLogAddressText()
    {
        WaitForElementVisible(By.XPath(_orderLogAddress));

        string addressText = driver.FindElement(By.XPath(_orderLogAddress)).Text;

        return addressText;
    }


    public Address CreateOrder()
    {
        Address orderAddress = new()
        {
            Province = OrderDataGenerator.RandomProvince,
            District = OrderDataGenerator.RandomCity,
            Street = OrderDataGenerator.RandomStreet,
            ZipCode = OrderDataGenerator.RandomZipCode,
            Line = OrderDataGenerator.RandomLine
        };

        SendKeysToElement("province", orderAddress.Province);
        SendKeysToElement("district", orderAddress.District);
        SendKeysToElement("street", orderAddress.Street);
        SendKeysToElement("zipCode", orderAddress.ZipCode);
        SendKeysToElement("line", orderAddress.Line);

        ProceedToNextPage();

        SendKeysToElement("cardHolderName", OrderDataGenerator.RandomCardHolderName);
        SendKeysToElement("cardNumber", OrderDataGenerator.RandomCardNumber);
        SendKeysToElement("cardSecurityNumber", OrderDataGenerator.RandomCardSecurityNumber);
        SendKeysToElement("cardTypeId", OrderDataGenerator.RandomCardTypeId);

        ProceedToNextPage();
        ProceedToNextPage();

        return orderAddress;
    }


}
