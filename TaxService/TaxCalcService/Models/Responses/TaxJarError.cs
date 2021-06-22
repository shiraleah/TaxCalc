using Newtonsoft.Json;

namespace TaxCalcService.Models.Responses
{
    public class TaxJarError
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}