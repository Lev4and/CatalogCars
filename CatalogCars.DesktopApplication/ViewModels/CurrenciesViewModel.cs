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
    public class CurrenciesViewModel : BindableBase
    {
        private readonly CurrenciesRequester _сurrenciesRequester;

        public Pagination Pagination { get; set; }

        public CurrenciesFilters Filters { get; set; }

        public ObservableCollection<Currency> Currencies { get; set; }

        public ObservableCollection<string> NamesCurrencies { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesCurrenciesAsync();
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

        public CurrenciesViewModel()
        {
            _сurrenciesRequester = new CurrenciesRequester();
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
                CountTotalItems = (await _сurrenciesRequester.GetCountCurrenciesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new CurrenciesFilters();

            await ResetPaginationAsync();
            await GetNamesCurrenciesAsync();
            await SearchAsync();
        }

        private async Task GetNamesCurrenciesAsync()
        {
            NamesCurrencies = new ObservableCollection<string>((await _сurrenciesRequester.GetNamesCurrenciesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Currencies = new ObservableCollection<Currency>((await _сurrenciesRequester.GetCurrenciesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var currencies = await _сurrenciesRequester.GetCurrenciesAsync(Filters);

                    foreach (var currency in currencies)
                    {
                        Currencies.Add(currency);
                    }
                }
            }
        }
    }
}
