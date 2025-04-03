namespace Tests.Tests;

public class AuthTest : BaseTest
{
    [Test]
    public void Authenticate_WithValidCredentials()
    {
        var authPage = homePage.GoToAuthPage();
        authPage.LogIn();
        homePage.WaitUntilIsRedirected();
        Assert.That(homePage.IsLoggedIn);
    }

    [Test]
    [TestCase("wrong@example.com", "password")]
    [TestCase("email@example.com", "wrongPassword")]
    public void Authenticate_WithInvalidCredentials(string email, string password)
    {
        var authPage = homePage.GoToAuthPage();
        authPage.LogIn(email: email, password: password);

        Assert.IsTrue(homePage.IsErrorFrameDisplayed());
    }
}
