using currency.marshallzehr.business.Interface;
using currency.marshallzehr.data;
using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace currency.marshallzehr.business
{
    public sealed class CurrencyUnitBusiness
    {
        

        private CurrencyUnitBusiness()
        {

        }
        

        private static Dictionary<string, CurrencyUnit> _instance;
        public static async Task<Dictionary<string, CurrencyUnit>> GetInstanceAsync()
        {
            
            if (_instance==null) 
            {
                ICurrencyRepository _repository=new CurrencyRepository();
                IConfigBusiness _configBusiness = new ConfigBusiness();
                try
                {
                    _instance = new Dictionary<string, CurrencyUnit>();
                    var url = _configBusiness.Get("unitDataUrl");
                    var basecurrency = _configBusiness.Get("baseCurrency");
                    var requestedCurrencies= _configBusiness.Get("requestedCurrencies").Split(",");
                    var api_response = await _repository.GetAsync<List<CurrencyUnit>>(url);
                    foreach (var item in api_response.Where(x=> !string.IsNullOrWhiteSpace(x.AlphabeticCode))) 
                    {
                        if (!requestedCurrencies.Contains(item.AlphabeticCode)) continue;
                        if (_instance.Keys.Contains(item.AlphabeticCode)) continue;
                        if (item.AlphabeticCode.Equals(basecurrency)) { item.IsBase = true; }
                        _instance.Add(item.AlphabeticCode, item);
                    }
                    
                }
                catch(Exception ex)
                {
                    
                    _instance = null;
                    throw ex;
                }
                finally 
                {
                    _repository.Dispose();
                    _configBusiness.Dispose();
                    
                }
                
            }
            return _instance;
        }

      
    }
}
