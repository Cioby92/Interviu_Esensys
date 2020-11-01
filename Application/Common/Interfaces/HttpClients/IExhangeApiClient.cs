using Essensys.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Essensys.Application.Common.HttpClients
{
    public interface IExchangeApiClient
    {
        Task<ResponseRates> GetExchangeRate(string SourceExhcangeValue, string DestinationExchangeValue);
    }
}
