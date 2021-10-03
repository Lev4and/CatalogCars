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
    public class ColorsViewModel : BindableBase
    {
        private readonly ColorsRequester _colorsRequester;

        public Pagination Pagination { get; set; }

        public ColorsFilters Filters { get; set; }

        public ObservableCollection<Color> Colors { get; set; }

        public ObservableCollection<string> NamesColors { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesColorsAsync();
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

        public ColorsViewModel()
        {
            _colorsRequester = new ColorsRequester();
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
                CountTotalItems = (await _colorsRequester.GetCountColorsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new ColorsFilters();

            await ResetPaginationAsync();
            await GetNamesColorsAsync();
            await SearchAsync();
        }

        private async Task GetNamesColorsAsync()
        {
            NamesColors = new ObservableCollection<string>((await _colorsRequester.GetNamesColorsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Colors = new ObservableCollection<Color>((await _colorsRequester.GetColorsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var colors = await _colorsRequester.GetColorsAsync(Filters);

                    foreach (var color in colors)
                    {
                        Colors.Add(color);
                    }
                }
            }
        }
    }
}
