using Newtonsoft.Json;

namespace TaxCalcService.Models.Responses
{
    public class Location
    {
        [JsonProperty("rate")]
        public Rate Rate { get; set; }
    }
}