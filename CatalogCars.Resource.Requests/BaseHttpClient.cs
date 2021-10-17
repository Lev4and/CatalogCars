using System;
using System.Net.Http;

namespace CatalogCars.Resource.Requests
{
    public class BaseHttpClient
    {
        private string _baseUrl;

        private protected HttpClient _client;
        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        public BaseHttpClient(string pathAndQueryUrl)
        {
            //_baseUrl = $"https://localhost:5001/api/{pathAndQueryUrl}";
            //_baseUrl = $"https://localhost:44377/api/{pathAndQueryUrl}";
            _baseUrl = $"http://resource.api.u1321851.plsk.regruhosting.ru/api/{pathAndQueryUrl}";

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = true;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(_baseUrl);
        }
    }
}
