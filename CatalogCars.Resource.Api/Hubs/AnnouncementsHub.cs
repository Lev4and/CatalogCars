using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using CatalogCars.Model.Parsers.AutoRu.JsonWorkers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Api.Hubs
{
    public class AnnouncementsHub : Hub
    {
        private readonly CarsCookieWorker _cookieWorker;
        private readonly CarsJsonWorker _jsonWorker;

        public AnnouncementsHub()
        {
            _cookieWorker = new CarsCookieWorker();
            _jsonWorker = new CarsJsonWorker();
        }

        public async Task Send()
        {
            var topDays = 1;
            var pageSize = 37;
            var currentTime = DateTime.Now.AddMinutes(-5);
            var rangePrice = new RangePrice(300000000, 0);
            var rangeMileage = new RangeMileage(1100000, 0);

            var announcements = new List<Announcement>();

            var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(rangeMileage, rangePrice, 1, 1, 1);

            var maxNumberPage = Convert.ToInt32(JsonConvert.DeserializeObject<dynamic>((await _jsonWorker.GetCars(headers,
                    rangeMileage, rangePrice, pageSize, topDays, 1))).pagination.total_page_count);

            for (int z = 1; z <= 1; z++)
            {
                announcements.AddRange(JsonConvert.DeserializeObject<Result>(await _jsonWorker.GetCars(headers,
                    rangeMileage, rangePrice, pageSize, topDays, z)).Announcements.Where(announcement =>
                        announcement.AdditionalInfo.CreatedAt >= currentTime).OrderBy(announcement =>
                            announcement.AdditionalInfo.CreatedAt));
            }

            await Clients.Caller.SendAsync("Receive", announcements.ToArray());
        }
    }
}
