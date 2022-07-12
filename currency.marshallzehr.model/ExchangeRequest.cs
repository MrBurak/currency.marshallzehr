using System;

namespace currency.marshallzehr.model
{
    public class ExchangeRequest
    {
        public string SourceUnit { get; set; }
        public string TargetUnit { get; set; }

        
        public string UnitPrefix { get { return $"FX{SourceUnit}{TargetUnit}"; } }
        public DateTime? dateTime { get; set; }
    }
    public class ExchangeResult: ExchangeRequest
    {
        
        public decimal TargetValue { get; set; }
        public decimal RateValue { get; set; }
        public decimal SourceValue { get; set; }
    }
}
