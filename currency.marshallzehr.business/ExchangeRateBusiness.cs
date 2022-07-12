using currency.marshallzehr.business.Interface;
using currency.marshallzehr.data;
using currency.marshallzehr.model;
using System;
using System.Linq;

namespace currency.marshallzehr.business
{
    public class ExchangeRateBusiness :IDisposable
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IConfigBusiness _configBusiness;
        private bool disposedValue;

        public ExchangeRateBusiness()
        {
            _currencyRepository = new CurrencyRepository();
            _configBusiness = new ConfigBusiness();
        }
        

        
        public Observation GetRate(DateTime? dateTime, string fx, out bool nodata)
        {
            var url = _configBusiness.Get("baseDataUrl");
            url += $"/observations/{fx}/json";
            try
            {
                Observation valueobject = null;
                var api_response = _currencyRepository.Get<BankResponse>(url, new CustomContractResolver(fx));
                if (dateTime == null)
                {
                    valueobject = api_response.Observations.LastOrDefault();
                }
                else 
                {
                    valueobject = api_response.Observations.FirstOrDefault(x => x.Date.Equals(dateTime));
                    
                }
                nodata = valueobject == null;
                return valueobject;

            }
            catch
            {
                nodata = false;
                return null;
            }
            


            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _configBusiness.Dispose();
                    _currencyRepository.Dispose();
                }
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
