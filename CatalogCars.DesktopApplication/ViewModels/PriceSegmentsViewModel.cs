using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class PriceSegmentsViewModel : BindableBase
    {
        private readonly PriceSegmentsRequester _priceSegmentsRequester;

        public Pagination Pagination { get; set; }

        public PriceSegmentsFilters Filters { get; set; }

        public ObservableCollection<string> NamesPriceSegments { get; set; }

        public ObservableCollection<PriceSegment> PriceSegments { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesPriceSegmentsAsync();
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

        public PriceSegmentsViewModel()
        {
            _priceSegmentsRequester = new PriceSegmentsRequester();
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
                CountTotalItems = (await _priceSegmentsRequester.GetCountPriceSegmentsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new PriceSegmentsFilters();

            await ResetPaginationAsync();
            await GetNamesPriceSegmentsAsync();
            await SearchAsync();
        }

        private async Task GetNamesPriceSegmentsAsync()
        {
            NamesPriceSegments = new ObservableCollection<string>((await _priceSegmentsRequester.GetNamesPriceSegmentsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            PriceSegments = new ObservableCollection<PriceSegment>((await _priceSegmentsRequester.GetPriceSegmentsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var priceSegments = await _priceSegmentsRequester.GetPriceSegmentsAsync(Filters);

                    foreach (var priceSegment in priceSegments)
                    {
                        PriceSegments.Add(priceSegment);
                    }
                }
            }
        }
    }
}
