using CatalogCars.Model.Converters.AutoRu;
using System;

namespace CatalogCars.Resource.Requests.HubEventArgs
{
    public class AnnouncementsHubEventArgs : EventArgs
    {
        public Announcement[] Announcements { get; }

        public AnnouncementsHubEventArgs(Announcement[] announcements)
        {
            Announcements = announcements;
        }
    }
}
