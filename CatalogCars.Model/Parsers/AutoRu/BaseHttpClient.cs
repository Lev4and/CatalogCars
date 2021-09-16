using CatalogCars.Model.Parsers.AutoRu.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CatalogCars.Model.Parsers.AutoRu
{
    public class BaseHttpClient
    {
        private string _baseUrl;

        private protected HttpClient _client;
        private protected HttpClient _ajaxClient;

        private protected HttpContent _content;
        private protected HttpClientHandler _handler;

        private protected CookieContainer _cookieContainer;

        public BaseHttpClient(string pathAndQueryUrl)
        {
            _baseUrl = $"https://www.auto.ru/{pathAndQueryUrl}";

            _cookieContainer = new CookieContainer();

            _handler = new HttpClientHandler();
            _handler.AllowAutoRedirect = true;
            _handler.CookieContainer = _cookieContainer;
            _handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.Brotli;
            _handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            _client = new HttpClient(_handler);
            _ajaxClient = new HttpClient(_handler);

            _client.BaseAddress = new Uri(_baseUrl);
            _ajaxClient.BaseAddress = new Uri($"{_baseUrl}-/ajax/desktop/");

            _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _client.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not; A Brand\";v=\"99\", \"Yandex\";v=\"91\", \"Chromium\";v=\"91\"");
            _client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            _client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 YaBrowser/21.6.4.787 Yowser/2.5 Safari/537.36");
            _client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            _client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            _client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            _client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            _client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _client.DefaultRequestHeaders.Add("Accept-Language", "ru,en;q=0.9");
        }

        public List<Cookie> GetCookies()
        {
            return _cookieContainer.GetCookies(new Uri($"{_client.BaseAddress}")).Cast<Cookie>().ToList();
        }

        public List<Cookie> GetCookies(string url)
        {
            return _cookieContainer.GetCookies(new Uri($"{_client.BaseAddress}{url}")).Cast<Cookie>().ToList();
        }

        public void SetAjaxRequestHeaders(HeadersAjaxRequestForCars headers)
        {
            if (headers != null)
            {
                _ajaxClient.DefaultRequestHeaders.Clear();

                _ajaxClient.DefaultRequestHeaders.Add("Host", "auto.ru");
                _ajaxClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                _ajaxClient.DefaultRequestHeaders.Add("sec-ch-ua", "\" Not; A Brand\";v=\"99\", \"Yandex\";v=\"91\", \"Chromium\";v=\"91\"");
                _ajaxClient.DefaultRequestHeaders.Add("x-csrf-token", headers.CsrfToken);
                _ajaxClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
                _ajaxClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 YaBrowser/21.6.4.787 Yowser/2.5 Safari/537.36");
                _ajaxClient.DefaultRequestHeaders.Add("x-requested-with", "fetch");
                _ajaxClient.DefaultRequestHeaders.Add("Accept", "*/*");
                _ajaxClient.DefaultRequestHeaders.Add("Origin", "https://auto.ru");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "same-origin");
                _ajaxClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                _ajaxClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                _ajaxClient.DefaultRequestHeaders.Add("Accept-Language", "ru,en;q=0.9");
                _ajaxClient.DefaultRequestHeaders.Add("Cookie", headers.CookieContent);
            }
        }
    }
}
