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
    public class GearTypesViewModel : BindableBase
    {
        private readonly GearTypesRequester _gearTypesRequester;

        public Pagination Pagination { get; set; }

        public GearTypesFilters Filters { get; set; }

        public ObservableCollection<string> NamesGearTypes { get; set; }

        public ObservableCollection<GearType> GearTypes { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesGearTypesAsync();
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

        public GearTypesViewModel()
        {
            _gearTypesRequester = new GearTypesRequester();
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
                CountTotalItems = (await _gearTypesRequester.GetCountGearTypesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new GearTypesFilters();

            await ResetPaginationAsync();
            await GetNamesGearTypesAsync();
            await SearchAsync();
        }

        private async Task GetNamesGearTypesAsync()
        {
            NamesGearTypes = new ObservableCollection<string>((await _gearTypesRequester.GetNamesGearTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            GearTypes = new ObservableCollection<GearType>((await _gearTypesRequester.GetGearTypesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var gearTypes = await _gearTypesRequester.GetGearTypesAsync(Filters);

                    foreach (var gearType in gearTypes)
                    {
                        GearTypes.Add(gearType);
                    }
                }
            }
        }
    }
}
