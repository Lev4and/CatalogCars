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
    public class ColorTypesViewModel : BindableBase
    {
        private readonly ColorTypesRequester _colorTypesRequester;

        public Pagination Pagination { get; set; }

        public ColorTypesFilters Filters { get; set; }

        public ObservableCollection<ColorType> ColorTypes { get; set; }

        public ObservableCollection<string> NamesColorTypes { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesColorTypesAsync();
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

        public ColorTypesViewModel()
        {
            _colorTypesRequester = new ColorTypesRequester();
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
                CountTotalItems = (await _colorTypesRequester.GetCountColorTypesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new ColorTypesFilters();

            await ResetPaginationAsync();
            await GetNamesColorTypesAsync();
            await SearchAsync();
        }

        private async Task GetNamesColorTypesAsync()
        {
            NamesColorTypes = new ObservableCollection<string>((await _colorTypesRequester.GetNamesColorTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            ColorTypes = new ObservableCollection<ColorType>((await _colorTypesRequester.GetColorTypesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var colorTypes = await _colorTypesRequester.GetColorTypesAsync(Filters);

                    foreach (var colorType in colorTypes)
                    {
                        ColorTypes.Add(colorType);
                    }
                }
            }
        }
    }
}
