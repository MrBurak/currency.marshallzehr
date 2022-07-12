using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace currency.marshallzehr.model
{
    public class BankResponse
    {
        [JsonPropertyName("observations")]
        public List<Observation> Observations { get; set; }
    }

    public class Observation 
    {
        
        public DateTime Date { get; set; }

        public ObservationValue Unit { get; set; }

    }

    public class ObservationValue
    {
        [JsonPropertyName("v")]
        public object v { get; set; }
    }

}
