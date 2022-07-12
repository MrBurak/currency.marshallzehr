using System;
using System.Collections.Generic;
using System.Text;

namespace currency.marshallzehr.business.Interface
{
    public interface IConfigBusiness : IDisposable
    {
        string Get(string key);
    }
}
