using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests
{
    public class BaseHubClient
    {
        protected private HubConnection _connection;

        public bool IsBusy { get; set; }

        public bool IsConnected { get; set; }

        public BaseHubClient(string pathAndQueryUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"{ServerUrl.Global}{pathAndQueryUrl}", (options) => 
                {
                    options.HttpMessageHandlerFactory = (message) =>
                    {
                        if (message is HttpClientHandler clientHandler)
                        {
                            clientHandler.ServerCertificateCustomValidationCallback +=
                                (sender, certificate, chain, sslPolicyErrors) => { return true; };
                        }

                        return message;
                    };
                })
                .Build();
        }

        public async Task Connect()
        {
            if (!IsConnected)
            {
                try
                {
                    await _connection.StartAsync();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    IsConnected = true;
                }
            }
        }

        public async Task Disconnect()
        {
            if (IsConnected)
            {
                try
                {
                    await _connection.StopAsync();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    IsConnected = false;
                }
            }
        }
    }
}
