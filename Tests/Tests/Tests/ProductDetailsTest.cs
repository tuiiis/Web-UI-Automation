using Tests.PageObject;

namespace Tests.Tests;

public class ProductDetailsTest : BaseTest
{
    [Test]
    public void GetProductDetails()
    {
        DetailsPage detailsPage;
        string plantName;
        (detailsPage, plantName) = homePage.GoToProductDetails();

        string productName = detailsPage.ProductsNameInDetails();

        Assert.That(productName.Equals(plantName));
    }
}
