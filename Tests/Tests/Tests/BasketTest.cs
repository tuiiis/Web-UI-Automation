namespace Tests.Tests;

public class BasketTest : BaseTest
{
    [Test]
    public void AddItemToBasket_Authorized()
    {
        var authPage = homePage.GoToAuthPage();
        authPage.LogIn();
        homePage.WaitUntilIsRedirected();

        var basketPage = homePage.GoToBasketPage();
        basketPage.EmptyBasket();
        basketPage.GoToHomePage();
        homePage.WaitUntilIsRedirected();

        string plantName = homePage.AddItemToBasket();

        homePage.GoToBasketPage();

        var basketItemName = basketPage.BasketItemNameText();

        Assert.That(basketItemName, Does.Contain(plantName));
    }

    [Test]
    public void AddItemToBasket_Unauthorized()
    {
        homePage.AddItemToBasket();

        Assert.IsTrue(homePage.IsErrorFrameDisplayed());
    }
}
