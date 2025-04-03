using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PageObject;

public class DetailsPage(IWebDriver driver) : BasePage(driver)
{
    private const string productNameInDetailsXPath = "//p[@data-testid='product-name']";

    public string ProductsNameInDetails()
    {
        return driver.FindElement(By.XPath(productNameInDetailsXPath)).Text;
    }
}
