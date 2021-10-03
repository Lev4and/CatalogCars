using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class SteeringWheelsViewModel : BindableBase
    {
        private readonly SteeringWheelsRequester _steeringWheelsRequester;

        public Pagination Pagination { get; set; }

        public SteeringWheelsFilters Filters { get; set; }

        public ObservableCollection<string> NamesSteeringWheels { get; set; }

        public ObservableCollection<SteeringWheel> SteeringWheels { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesSteeringWheelsAsync();
        });

        public ICommand Loaded => new AsyncCommand(() =>
        {
            return LoadedAsync();
        });

        public ICommand Search => new AsyncCommand(() =>
        {
            return SearchAsync();
        });

        public ICommand Reset => new AsyncCommand(() =>
        {
            return ResetAsync();
        });

        public ICommand Info => new AsyncCommand(() =>
        {
            return new Task(() => { });
        });

        public SteeringWheelsViewModel()
        {
            _steeringWheelsRequester = new SteeringWheelsRequester();
        }

        private async Task LoadedAsync()
        {
            await ResetAsync();
        }

        private async Task ResetPaginationAsync()
        {
            Pagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _steeringWheelsRequester.GetCountSteeringWheelsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new SteeringWheelsFilters();

            await ResetPaginationAsync();
            await GetNamesSteeringWheelsAsync();
            await SearchAsync();
        }

        private async Task GetNamesSteeringWheelsAsync()
        {
            NamesSteeringWheels = new ObservableCollection<string>((await _steeringWheelsRequester.GetNamesSteeringWheelsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            SteeringWheels = new ObservableCollection<SteeringWheel>((await _steeringWheelsRequester.GetSteeringWheelsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var steeringWheels = await _steeringWheelsRequester.GetSteeringWheelsAsync(Filters);

                    foreach (var steeringWheel in steeringWheels)
                    {
                        SteeringWheels.Add(steeringWheel);
                    }
                }
            }
        }
    }
}
