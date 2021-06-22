using NUnit.Framework;
using TaxCalcService.Models.Payloads;
using TaxCalcService.Services;

namespace TaxCalcService.Tests
{
    public class Tests
    {
        [TestCase("", ExpectedResult = false)]
        [TestCase("20853", ExpectedResult = true)]
        [TestCase("20853", "", "Maryland", ExpectedResult = false)]
        [TestCase("20853", "", "MD", ExpectedResult = true)]
        [TestCase("20853", "", "Maryland", "Rockville", ExpectedResult = false)]
        public bool GetTaxRateForLocation(string zipcode, string country = "", string state = "", string city = "", string street = "")
        {
            var taxJarClientService = new TaxJarClientService();
            try
            {
                var locationRate = taxJarClientService.GetTaxRateForLocation(zipcode, country, state, city, street);
                return locationRate?.Rate != null;
            }
            catch
            {
                return false;
            }
        }

        [TestCase("US", 5, 25, "20853", "MD", "US", "20853", "MD", ExpectedResult = true)]
        [TestCase("US", 5, 25, "20853", ExpectedResult = false)]
        [TestCase("US", 5, 25, ExpectedResult = false)]
        [TestCase("CA", 5, 25, ExpectedResult = false)]
        [TestCase("United States", 5, 25, "20853", ExpectedResult = false)]
        public bool CalculateTaxesForOrder(string toCountry, float shipping, float amount, string toZip = null, string toState = null, string fromCountry = null, string fromZip = null, string fromState = null)
        {
            var taxJarClientService = new TaxJarClientService();

            try
            {
                var order = new Order
                {
                    ToCountry = toCountry,
                    Shipping = shipping,
                    Amount = amount,
                    ToZip = toZip,
                    ToState = toState,
                    FromCountry = fromCountry,
                    FromZip = fromZip,
                    FromState = fromState
                };

                var rate = taxJarClientService.CalculateTaxesForOrder(order);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}