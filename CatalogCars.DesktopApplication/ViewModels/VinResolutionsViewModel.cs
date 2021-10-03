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
    public class VinResolutionsViewModel : BindableBase
    {
        private readonly VinResolutionsRequester _vinResolutionsRequester;

        public Pagination Pagination { get; set; }

        public VinResolutionsFilters Filters { get; set; }

        public ObservableCollection<string> NamesVinResolutions { get; set; }

        public ObservableCollection<VinResolution> VinResolutions { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesVinResolutionsAsync();
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

        public VinResolutionsViewModel()
        {
            _vinResolutionsRequester = new VinResolutionsRequester();
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
                CountTotalItems = (await _vinResolutionsRequester.GetCountVinResolutionsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new VinResolutionsFilters();

            await ResetPaginationAsync();
            await GetNamesVinResolutionsAsync();
            await SearchAsync();
        }

        private async Task GetNamesVinResolutionsAsync()
        {
            NamesVinResolutions = new ObservableCollection<string>((await _vinResolutionsRequester.GetNamesVinResolutionsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            VinResolutions = new ObservableCollection<VinResolution>((await _vinResolutionsRequester.GetVinResolutionsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var vinResolutions = await _vinResolutionsRequester.GetVinResolutionsAsync(Filters);

                    foreach (var vinResolution in vinResolutions)
                    {
                        VinResolutions.Add(vinResolution);
                    }
                }
            }
        }
    }
}
