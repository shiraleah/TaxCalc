using Newtonsoft.Json;

namespace TaxCalcService.Models
{
    public class LineItem
    {
        [JsonProperty("line_items")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("product_tax_code")]
        public string ProductTaxCode { get; set; }

        [JsonProperty("unit_price")]
        public float UnitPrice { get; set; }

        [JsonProperty("discount")]
        public float Discount { get; set; }
    }
}