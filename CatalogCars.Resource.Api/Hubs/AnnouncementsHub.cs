using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Parsers.AutoRu.CookieWorkers;
using CatalogCars.Model.Parsers.AutoRu.JsonWorkers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
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
            while (true)
            {
                var headers = await _cookieWorker.GetHeadersAjaxRequestForCars(new RangeMileage(1100000, 0), new RangePrice(300000000, 0), 1, 1, 1);
                var carsJson = await _jsonWorker.GetCars(headers, new RangeMileage(1100000, 0), new RangePrice(300000000, 0), 37, 1, 1);
                var cars = JsonConvert.DeserializeObject<Result>(carsJson).Announcements.Where(announcement => 
                    announcement.AdditionalInfo.UpdatedAt >= DateTime.Now.AddMinutes(-10)).ToArray();

                if(cars.Length > 0)
                {
                    await Clients.All.SendAsync("Receive", cars);
                }

                await Task.Delay(60000);
            }
        }
    }
}
