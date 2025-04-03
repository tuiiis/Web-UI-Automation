using Faker;

namespace Tests.DataGenerator;

public static class OrderDataGenerator
{
    public static string RandomProvince => Address.Country();
    public static string RandomCity => Address.City();
    public static string RandomStreet => Address.StreetAddress();
    public static string RandomZipCode => Address.ZipCode();
    public static string RandomLine => RandomNumber.Next(1, 1000).ToString();
    public static string RandomName => Name.FullName();
    public static string RandomCardHolderName => Name.FullName();
    public static string RandomCardNumber => RandomNumber.Next(1000000000000000, 9999999999999999).ToString();
    public static string RandomCardSecurityNumber => RandomNumber.Next(100, 999).ToString();
    public static string RandomCardTypeId => RandomNumber.Next(2025, 2035).ToString();
}
