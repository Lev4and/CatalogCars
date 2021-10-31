using CatalogCars.Model.Converters.AutoRu;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Api.Hubs
{
    public class AnnouncementsHub : Hub
    {
        public AnnouncementsHub()
        {

        }

        public async Task Send(Announcement[] announcements)
        {
            await Clients.Others.SendAsync("Receive", announcements);
        }
    }
}
