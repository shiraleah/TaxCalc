using Newtonsoft.Json;

namespace TaxCalcService.Models.Responses
{
    public class Rate
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_rate")]
        public string CountryRate { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_rate")]
        public float StateRate { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("county_rate")]
        public float CountyRate { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_rate")]
        public float CityRate { get; set; }

        [JsonProperty("combined_district_rate")]
        public float CombinedDistrictRate { get; set; }

        [JsonProperty("combined_rate")]
        public float CombinedRate { get; set; }

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }
    }
}