using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HubClients;
using CatalogCars.Resource.Requests.HubEventArgs;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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

        public ICommand SelectedAnnouncementChanged => new AsyncCommand<Announcement>((announcement) =>
        {
            return OpenAnnouncementAsync(announcement);
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
        }

        private async Task UnloadedAsync()
        {
            await _announcementsHubClient.Disconnect();

            _announcementsHubClient.OnReceived -= (e) => OnReceived(e);
        }

        private async Task OpenAnnouncementAsync(Announcement announcement)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.auto.ru/{announcement.Category}/{announcement.Section}/sale/" +
                $"{announcement.Vehicle.Mark.Code}/{announcement.Vehicle.Model.Code}/{announcement.SaleId}/") { CreateNoWindow = true });
        }

        private async Task OnReceived(AnnouncementsHubEventArgs eventArgs)
        {
            if(eventArgs != null)
            {
                if(eventArgs.Announcements != null)
                {
                    var announcements = eventArgs.Announcements.ToList();

                    foreach (var announcement in announcements)
                    {
                        Announcements.Insert(0, announcement);
                    }
                }
            }
        }
    }
}
