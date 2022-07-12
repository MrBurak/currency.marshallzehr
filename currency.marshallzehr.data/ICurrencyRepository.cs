using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace currency.marshallzehr.data
{
    public interface ICurrencyRepository : IDisposable
    {
        Task<TResponseModel> GetAsync<TResponseModel>(string _apiUrl, DefaultContractResolver defaultContractResolver=null);
        TResponseModel Get<TResponseModel>(string _apiUrl, DefaultContractResolver defaultContractResolver = null);
    }
}
