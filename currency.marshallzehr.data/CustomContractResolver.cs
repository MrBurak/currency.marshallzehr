using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace currency.marshallzehr.data
{
    public class CustomContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> PropertyMappings { get; set; }

        public CustomContractResolver(string unit)
        {
            this.PropertyMappings = new Dictionary<string, string>
            {
                {"Date", "d"},
                {"Unit", unit}
            };
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName = null;
            var resolved = this.PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }
}
