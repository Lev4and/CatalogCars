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
    public class EngineTypesViewModel : BindableBase
    {
        private readonly EngineTypesRequester _engineTypesRequester;

        public Pagination Pagination { get; set; }

        public EngineTypesFilters Filters { get; set; }

        public ObservableCollection<string> NamesEngineTypes { get; set; }

        public ObservableCollection<EngineType> EngineTypes { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesEngineTypesAsync();
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

        public EngineTypesViewModel()
        {
            _engineTypesRequester = new EngineTypesRequester();
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
                CountTotalItems = (await _engineTypesRequester.GetCountEngineTypesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new EngineTypesFilters();

            await ResetPaginationAsync();
            await GetNamesEngineTypesAsync();
            await SearchAsync();
        }

        private async Task GetNamesEngineTypesAsync()
        {
            NamesEngineTypes = new ObservableCollection<string>((await _engineTypesRequester.GetNamesEngineTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            EngineTypes = new ObservableCollection<EngineType>((await _engineTypesRequester.GetEngineTypesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var engineTypes = await _engineTypesRequester.GetEngineTypesAsync(Filters);

                    foreach (var engineType in engineTypes)
                    {
                        EngineTypes.Add(engineType);
                    }
                }
            }
        }
    }
}
