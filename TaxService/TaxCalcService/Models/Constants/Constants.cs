namespace TaxCalcService.Models.Constants
{
    public class Constants
    {
        public static class TaxJarEndpoints
        {
            public const string ShowTaxRatesForLocation = "https://api.taxjar.com/v2/rates/";
            public const string CalculateSalesTaxForOrder = "https://api.taxjar.com/v2/taxes";
        }
    }
}