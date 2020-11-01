using Essensys.Application.Common.HttpClients;
using Essensys.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Essensys.Infrastructure.HttpClients
{
   public class ExchangeApiClient : IExchangeApiClient
    {
        private HttpClient _client { get; }
        public ExchangeApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseRates> GetExchangeRate(string SourceExhcangeValue,string DestinationExchangeValue)
        {
            var response = await _client.GetAsync($"?base={SourceExhcangeValue}&symbols={DestinationExchangeValue}");
            var responseStream =  response.Content.ReadAsStringAsync().Result;
            var rate = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseRates>(responseStream);
            return rate;
        }

    }
}
