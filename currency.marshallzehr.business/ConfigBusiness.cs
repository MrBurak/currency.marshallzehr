using currency.marshallzehr.business.Interface;
using System;
using System.Configuration;

namespace currency.marshallzehr.business
{
    public class ConfigBusiness : IConfigBusiness
    {
        private bool disposedValue;

        public string Get(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
