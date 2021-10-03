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
    public class TransmissionsViewModel : BindableBase
    {
        private readonly TransmissionsRequester _transmissionsRequester;

        public Pagination Pagination { get; set; }

        public TransmissionsFilters Filters { get; set; }

        public ObservableCollection<string> NamesTransmissions { get; set; }

        public ObservableCollection<Transmission> Transmissions { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesTransmissionsAsync();
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

        public TransmissionsViewModel()
        {
            _transmissionsRequester = new TransmissionsRequester();
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
                CountTotalItems = (await _transmissionsRequester.GetCountTransmissionsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new TransmissionsFilters();

            await ResetPaginationAsync();
            await GetNamesTransmissionsAsync();
            await SearchAsync();
        }

        private async Task GetNamesTransmissionsAsync()
        {
            NamesTransmissions = new ObservableCollection<string>((await _transmissionsRequester.GetNamesTransmissionsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Transmissions = new ObservableCollection<Transmission>((await _transmissionsRequester.GetTransmissionsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var transmissions = await _transmissionsRequester.GetTransmissionsAsync(Filters);

                    foreach (var transmission in transmissions)
                    {
                        Transmissions.Add(transmission);
                    }
                }
            }
        }
    }
}
