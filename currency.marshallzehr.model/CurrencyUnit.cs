using System.Text.Json.Serialization;

namespace currency.marshallzehr.model
{
    public class CurrencyUnit
    {
        [JsonPropertyName("AlphabeticCode")]
        public string AlphabeticCode { get; set; }
        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("Entity")]
        public string Entity { get; set; }

        public bool IsBase { get; set; }

    }
}

