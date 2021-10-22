using CatalogCars.Resource.Requests.HubClients;
using CatalogCars.Resource.Requests.HubEventArgs;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoRu = CatalogCars.Model.Converters.AutoRu;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class AnnouncementsOnlineViewModel : BindableBase
    {
        private readonly AnnouncementsHubClient _announcementsHubClient;

        public ObservableCollection<AutoRu.Announcement> Announcements { get; set; }

        public ICommand Loaded => new AsyncCommand(() =>
        {
            return LoadedAsync();
        });

        public ICommand Unloaded => new AsyncCommand(() =>
        {
            return UnloadedAsync();
        });

        public AnnouncementsOnlineViewModel()
        {
            _announcementsHubClient = new AnnouncementsHubClient();
            _announcementsHubClient.OnReceived += (e) => OnReceived(e);
        }

        private async Task LoadedAsync()
        {
            Announcements = new ObservableCollection<AutoRu.Announcement>();

            await _announcementsHubClient.Connect();
            await _announcementsHubClient.Send();
        }

        private async Task UnloadedAsync()
        {
            await _announcementsHubClient.Disconnect();

            _announcementsHubClient.OnReceived -= (e) => OnReceived(e);
        }

        private void OnReceived(AnnouncementsHubEventArgs eventArgs)
        {
            if(eventArgs != null)
            {
                if(eventArgs.Announcements != null)
                {
                    foreach(var announcement in eventArgs.Announcements)
                    {
                        Announcements.Insert(0, announcement);
                    }
                }
            }
        }
    }
}
