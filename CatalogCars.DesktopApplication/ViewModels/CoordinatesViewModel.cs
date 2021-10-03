using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class CoordinatesViewModel : BindableBase
    {
        private readonly RegionsRequester _regionsRequester;
        private readonly CoordinatesRequester _coordinatesRequester;

        public Pagination Pagination { get; set; }

        public CoordinatesFilters Filters { get; set; }

        public Pagination RegionsPagination { get; set; }

        public RegionsFilters RegionsFilters { get; set; }

        public ObservableCollection<string> NamesCoordinates { get; set; }

        public ObservableCollection<Entities.Coordinate> Coordinates { get; set; }

        public ObservableCollection<Entities.RegionInformation> Regions { get; set; }

        public ICommand RegionsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return RegionsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesCoordinatesAsync();
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

        public CoordinatesViewModel()
        {
            _regionsRequester = new RegionsRequester();
            _coordinatesRequester = new CoordinatesRequester();
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
                CountTotalItems = (await _coordinatesRequester.GetCountCoordinatesAsync(Filters))
            };
        }

        private async Task ResetRegionsPaginationAsync()
        {
            RegionsPagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _regionsRequester.GetCountRegionsAsync(RegionsFilters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new CoordinatesFilters();
            RegionsFilters = new RegionsFilters();

            await ResetPaginationAsync();
            await ResetRegionsPaginationAsync();

            await GetNamesCoordinatesAsync();

            await SearchAsync();
            await SearchRegionsAsync();
        }

        private async Task GetNamesCoordinatesAsync()
        {
            NamesCoordinates = new ObservableCollection<string>((await _coordinatesRequester.GetNamesCoordinatesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Coordinates = new ObservableCollection<Entities.Coordinate>((await _coordinatesRequester.GetCoordinatesAsync(Filters)).ToList());
        }

        private async Task SearchRegionsAsync()
        {
            RegionsFilters.ResetForSearch();

            await ResetRegionsPaginationAsync();

            Regions = new ObservableCollection<Entities.RegionInformation>((await _regionsRequester.GetRegionsAsync(RegionsFilters)).ToList());
        }

        private async Task RegionsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (RegionsPagination.NumberPage < RegionsPagination.MaxNumberPage)
                {
                    RegionsFilters.NumberPage += 1;
                    RegionsPagination.NumberPage += 1;

                    var regions = await _regionsRequester.GetRegionsAsync(RegionsFilters);

                    foreach (var region in regions)
                    {
                        Regions.Add(region);
                    }
                }
            }
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var coordinates = await _coordinatesRequester.GetCoordinatesAsync(Filters);

                    foreach (var coordinate in coordinates)
                    {
                        Coordinates.Add(coordinate);
                    }
                }
            }
        }
    }
}
