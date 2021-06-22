using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TaxCalcService.Interfaces;
using TaxCalcService.Models;
using TaxCalcService.Models.Constants;
using TaxCalcService.Models.Payloads;
using TaxCalcService.Models.Responses;

namespace TaxCalcService.Services
{
    public class TaxJarClientService : BaseClientService, ITaxJarClientService
    {
        public Location GetTaxRateForLocation(string zipcode, string country = "", string state = "", string city = "", string street = "")
        {
            var url = $"{Constants.TaxJarEndpoints.ShowTaxRatesForLocation}{zipcode}";

            if (!string.IsNullOrEmpty(country))
            {
                url = $"{url}?country={country}";
            }

            if (!string.IsNullOrEmpty(state))
            {
                url = url + (url.Contains("?") ? "&" : "?") + $"state={state}";
            }

            if (!string.IsNullOrEmpty(city))
            {
                url = url + (url.Contains("?") ? "&" : "?") + $"city={city}";
            }

            if (!string.IsNullOrEmpty(street))
            {
                url = url + (url.Contains("?") ? "&" : "?") + $"street={street}";
            }

            return Get<Location>(url);
        }

        public float CalculateTaxesForOrder(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var result = Post<OrderResult>(json, Constants.TaxJarEndpoints.CalculateSalesTaxForOrder);

            if (result == null)
            {
                throw new Exception("An error has occurred");
            }

            return result.Tax.AmountToCollect;
        }
    }
}