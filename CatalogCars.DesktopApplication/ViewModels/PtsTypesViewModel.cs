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
    public class PtsTypesViewModel : BindableBase
    {
        private readonly PtsTypesRequester _ptsTypesRequester;

        public Pagination Pagination { get; set; }

        public PtsTypesFilters Filters { get; set; }

        public ObservableCollection<string> NamesPtsTypes { get; set; }

        public ObservableCollection<PtsType> PtsTypes { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesPtsTypesAsync();
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

        public PtsTypesViewModel()
        {
            _ptsTypesRequester = new PtsTypesRequester();
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
                CountTotalItems = (await _ptsTypesRequester.GetCountPtsTypesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new PtsTypesFilters();

            await ResetPaginationAsync();
            await GetNamesPtsTypesAsync();
            await SearchAsync();
        }

        private async Task GetNamesPtsTypesAsync()
        {
            NamesPtsTypes = new ObservableCollection<string>((await _ptsTypesRequester.GetNamesPtsTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            PtsTypes = new ObservableCollection<PtsType>((await _ptsTypesRequester.GetPtsTypesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var ptsTypes = await _ptsTypesRequester.GetPtsTypesAsync(Filters);

                    foreach (var ptsType in ptsTypes)
                    {
                        PtsTypes.Add(ptsType);
                    }
                }
            }
        }
    }
}
