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
    public class RegionsViewModel : BindableBase
    {
        private readonly RegionsRequester _regionsRequester;

        public Pagination Pagination { get; set; }

        public RegionsFilters Filters { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public ObservableCollection<RegionInformation> Regions { get; set; }

        public ObservableCollection<string> NamesRegions { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesRegionsAsync();
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

        public RegionsViewModel()
        {
            _regionsRequester = new RegionsRequester();

            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" }
            };
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
                CountTotalItems = (await _regionsRequester.GetCountRegionsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new RegionsFilters();

            await ResetPaginationAsync();
            await GetNamesRegionsAsync();
            await SearchAsync();
        }

        private async Task GetNamesRegionsAsync()
        {
            NamesRegions = new ObservableCollection<string>((await _regionsRequester.GetNamesRegionsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Regions = new ObservableCollection<RegionInformation>((await _regionsRequester.GetRegionsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var regions = await _regionsRequester.GetRegionsAsync(Filters);

                    foreach (var region in regions)
                    {
                        Regions.Add(region);
                    }
                }
            }
        }
    }
}
