using OpenQA.Selenium;

namespace Tests.PageObject;

public class AuthPage(IWebDriver driver) : BasePage(driver)
{
    private readonly string _emailFieldId = "email";
    private readonly string _passwordFieldId = "password";
    private readonly string _nameFieldId = "name";

    private const string _testEmail = "test@example.com";
    private const string _testPassword = "Password1234";

    private readonly string _submitButtonXPath = "//button[@type='submit']";
    private readonly string _signUpLinkXPath = "//a[@href='Signup']";

    public void LogIn(string email = _testEmail, string password = _testPassword)
    {
        SendKeysToElement(_emailFieldId, email);
        SendKeysToElement(_passwordFieldId, password);
        driver.FindElement(By.XPath(_submitButtonXPath)).Click();
    }

    public void RegisterUser(string name, string email, string password)
    {
        driver.FindElement(By.XPath(_signUpLinkXPath)).Click();
        SendKeysToElement(_nameFieldId, name);
        SendKeysToElement(_emailFieldId, email);
        SendKeysToElement(_passwordFieldId, password);
        driver.FindElement(By.XPath(_submitButtonXPath)).Click();
    }
}
