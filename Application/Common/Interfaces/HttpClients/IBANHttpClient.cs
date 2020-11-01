using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Essensys.Application.Common.HttpClients
{
    public interface IBANHttpClient
    {
        Task<HttpResponseMessage> GetValidIban();
    }
}
