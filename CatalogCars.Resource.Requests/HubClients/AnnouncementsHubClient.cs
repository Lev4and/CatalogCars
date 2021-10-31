using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HubEventArgs;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Requests.HubClients
{
    public class AnnouncementsHubClient : BaseHubClient
    {
        public event Action<AnnouncementsHubEventArgs> OnReceived;

        public AnnouncementsHubClient() : base("autoRu/announcements/online")
        {
            _connection.On<Announcement[]>("Receive", (announcements =>
            {
                OnReceived?.Invoke(new AnnouncementsHubEventArgs(announcements));
            }));
        }

        public async Task Send(Announcement[] announcements)
        {
            IsBusy = true;

            try
            {
                await _connection.InvokeAsync("Send", announcements);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
