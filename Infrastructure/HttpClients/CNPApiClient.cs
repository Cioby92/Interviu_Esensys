using Essensys.Application.Common.HttpClients;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Essensys.Infrastructure.HttpClients
{
    public class CNPApiClient : ICNPHttpClient
    {
        private  HttpClient _client { get; }

        public CNPApiClient(HttpClient client)
        {

            _client = client;
        }
        public async Task<string> GetValidCnp()
        {
            HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("action","generate")
            });
            try
            {
            var response = await _client.PostAsync("/",content);
            var responseStream = await response.Content.ReadAsStringAsync();
            return responseStream.ToString();
            }
            catch(Exception e)
            {
                return e.ToString();
            }
           
        }

        public Task<bool> ValidateCnp()
        {
            throw new NotImplementedException();
        }
    }
}
