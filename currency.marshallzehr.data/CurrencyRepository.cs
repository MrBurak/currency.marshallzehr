using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace currency.marshallzehr.data
{
    /// <summary>
    /// Fettin data from api source
    /// </summary>
    public class CurrencyRepository : ICurrencyRepository
    {
        private bool disposedValue;

       public async Task<TResponseModel> GetAsync<TResponseModel>(string _apiUrl, DefaultContractResolver defaultContractResolver = null)
       {
            try
            {
                WebRequest webRequest = WebRequest.Create(_apiUrl);

              

                WebResponse resp = webRequest.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());

                string pageContent = await sr.ReadToEndAsync();

                TResponseModel responseModel;
                if (defaultContractResolver == null)
                {
                    responseModel = JsonConvert.DeserializeObject<TResponseModel>(pageContent);
                }
                else 
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        ContractResolver = defaultContractResolver
                    };
                    responseModel = JsonConvert.DeserializeObject<TResponseModel>(pageContent,settings);
                }
                

                return responseModel;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    if (ex.Response is HttpWebResponse err)
                    {
                        string htmlResponse = new StreamReader(err.GetResponseStream()).ReadToEnd();
                        string strErr = string.Format("{0} {1}", err.StatusDescription, htmlResponse);
                    }
                }
                else
                {
                    string strErr = ex.ToString();
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       public TResponseModel Get<TResponseModel>(string _apiUrl, DefaultContractResolver defaultContractResolver = null)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(_apiUrl);



                WebResponse resp = webRequest.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());

                string pageContent = sr.ReadToEnd();

                TResponseModel responseModel;
                if (defaultContractResolver == null)
                {
                    responseModel = JsonConvert.DeserializeObject<TResponseModel>(pageContent);
                }
                else
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        ContractResolver = defaultContractResolver
                    };
                    responseModel = JsonConvert.DeserializeObject<TResponseModel>(pageContent, settings);
                }


                return responseModel;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    if (ex.Response is HttpWebResponse err)
                    {
                        string htmlResponse = new StreamReader(err.GetResponseStream()).ReadToEnd();
                        string strErr = string.Format("{0} {1}", err.StatusDescription, htmlResponse);
                    }
                }
                else
                {
                    string strErr = ex.ToString();
                }
                throw ex;
            }
            catch (Exception ex)
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
