using TaxCalcService.Models.Payloads;
using TaxCalcService.Models.Responses;

namespace TaxCalcService.Interfaces
{
    public interface ITaxJarClientService
    {
        Location GetTaxRateForLocation(string zipcode, string country = "", string state = "", string city = "", string street = "");
        float CalculateTaxesForOrder(Order order);
    }
}