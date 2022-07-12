using currency.marshallzehr.business;
using currency.marshallzehr.business.Interface;
using currency.marshallzehr.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace currency.marshallzehr.app.Operations
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICurrencyUnitOperations : IDisposable
    {
        Task<Dictionary<string, CurrencyUnit>> GetCurrencyList();
        CurrencyUnit GetBase();
        CurrencyUnit GetCurrency(string code);

    }

    public class CurrencyUnitOperations : ICurrencyUnitOperations
    {
        private bool disposedValue;
        private readonly IConfigBusiness _configBusiness;
        public CurrencyUnitOperations(IConfigBusiness configBusiness)
        {
            _configBusiness = configBusiness;
        }

        public CurrencyUnit GetBase()
        {
            var code = _configBusiness.Get("baseCurrency");
            GetCurrencyList().Result.TryGetValue(code, out CurrencyUnit unit);
            return unit;
        }

        public CurrencyUnit GetCurrency(string code)
        {
            GetCurrencyList().Result.TryGetValue(code, out CurrencyUnit unit);
            return unit;
        }

        public async Task<Dictionary<string, CurrencyUnit>> GetCurrencyList()
        {
            return await CurrencyUnitBusiness.GetInstanceAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _configBusiness.Dispose();
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
