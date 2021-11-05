using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using CatalogCars.Model.Parsers.AutoRu.JsonWorkers;
using CatalogCars.Resource.Requests.HubClients;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoRu = CatalogCars.Model.Converters.AutoRu;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class AnnouncementsOnlineSearchViewModel
    {
        private readonly CarsJsonWorker _jsonWorker;
        private readonly CarsCookieWorker _cookieWorker;
        private readonly AnnouncementsHubClient _announcementsHubClient;

        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;

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

        public AnnouncementsOnlineSearchViewModel()
        {
            _jsonWorker = new CarsJsonWorker();
            _cookieWorker = new CarsCookieWorker();
            _announcementsHubClient = new AnnouncementsHubClient();

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            Announcements = new ObservableCollection<Announcement>();
        }

        private async Task LoadedAsync()
        {
            await _announcementsHubClient.Connect();
            await SearchAsync(_cancellationToken);
        }

        private async Task UnloadedAsync()
        {
            await _announcementsHubClient.Disconnect();

            _cancellationTokenSource.Cancel();
        }

        private async Task OpenAnnouncementAsync(Announcement announcement)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.auto.ru/{announcement.Category}/{announcement.Section}/sale/" +
                $"{announcement.Vehicle.Mark.Code}/{announcement.Vehicle.Model.Code}/{announcement.SaleId}/")
            { CreateNoWindow = true });
        }

        private async Task SearchAsync(CancellationToken cancellationToken)
        {
            var topDays = 1;
            var pageSize = 37;

            var rangePrice = new RangePrice(300000000, 0);
            var rangeMileage = new RangeMileage(1100000, 0);

            while (true)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(rangeMileage, rangePrice, 1, 1, 1);

                    var announcements = JsonConvert.DeserializeObject<Result>(await _jsonWorker.GetCars(headers,
                        rangeMileage, rangePrice, pageSize, topDays, 1)).Announcements.Where(announcement =>
                            announcement.AdditionalInfo.CreatedAt >= DateTime.Now.ToUniversalTime().AddMinutes(-5) &&
                                (Announcements.Count > 0 ? Announcements.All(a => a.SaleId !=
                                    announcement.SaleId) : true)).ToList();

                    if (announcements.Count > 0)
                    {
                        foreach (var announcement in announcements)
                        {
                            Announcements.Insert(0, announcement);
                        }

                        await _announcementsHubClient.Send(announcements.ToArray());
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
