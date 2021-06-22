using Newtonsoft.Json;

namespace TaxCalcService.Models.Responses
{
    public class Tax
    {
        [JsonProperty("order_total_amount")]
        public float OrderTotalAmount { get; set; }

        [JsonProperty("shipping")]
        public float Shipping { get; set; }

        [JsonProperty("taxable_amount")]
        public float TaxableAmount { get; set; }

        [JsonProperty("amount_to_collect")]
        public float AmountToCollect { get; set; }

        [JsonProperty("rate")]
        public float Rate { get; set; }

        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }
    }
}