namespace Tests.Tests;

public class OrderTest : BaseTest
{
    [Test]
    public void PlaceOrder_WithValidInput()
    {
        var authPage = homePage.GoToAuthPage();
        authPage.LogIn();
        homePage.WaitUntilIsRedirected();
        homePage.AddItemToBasket();

        var basketPage = homePage.GoToBasketPage();
        var orderPage = basketPage.GoToOrderPage();

        var address = orderPage.CreateOrder();

        homePage.GoToOrderLog();

        var addressText = orderPage.OrderLogAddressText();

        Assert.That(addressText, Does.Contain(address.Province));
        Assert.That(addressText, Does.Contain(address.Street));
        Assert.That(addressText, Does.Contain(address.Line));
        Assert.That(addressText, Does.Contain(address.ZipCode));
    }

    [Test]
    public void PlaceOrder_WithoutAddressInput()
    {
        var authPage = homePage.GoToAuthPage();
        authPage.LogIn();
        homePage.WaitUntilIsRedirected();
        homePage.AddItemToBasket();

        var basketPage = homePage.GoToBasketPage();
        var orderPage = basketPage.GoToOrderPage();

        orderPage.ProceedToNextPage();
        Assert.IsTrue(orderPage.IsAlertDisplayed());
    }
}
