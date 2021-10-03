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
    public class OptionsViewModel : BindableBase
    {
        private readonly OptionsRequester _optionsRequester;

        public Pagination Pagination { get; set; }

        public OptionsFilters Filters { get; set; }

        public ObservableCollection<string> NamesOptions { get; set; }

        public ObservableCollection<Option> Options { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesOptionsAsync();
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

        public OptionsViewModel()
        {
            _optionsRequester = new OptionsRequester();
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
                CountTotalItems = (await _optionsRequester.GetCountOptionsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new OptionsFilters();

            await ResetPaginationAsync();
            await GetNamesOptionsAsync();
            await SearchAsync();
        }

        private async Task GetNamesOptionsAsync()
        {
            NamesOptions = new ObservableCollection<string>((await _optionsRequester.GetNamesOptionsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Options = new ObservableCollection<Option>((await _optionsRequester.GetOptionsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var options = await _optionsRequester.GetOptionsAsync(Filters);

                    foreach (var option in options)
                    {
                        Options.Add(option);
                    }
                }
            }
        }
    }
}
