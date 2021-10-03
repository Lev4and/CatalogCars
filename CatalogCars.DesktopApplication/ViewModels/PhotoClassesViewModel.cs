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
    public class PhotoClassesViewModel : BindableBase
    {
        private readonly PhotoClassesRequester _photoClassesRequester;

        public Pagination Pagination { get; set; }

        public PhotoClassesFilters Filters { get; set; }

        public ObservableCollection<string> NamesPhotoClasses { get; set; }

        public ObservableCollection<PhotoClass> PhotoClasses { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesPhotoClassesAsync();
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

        public PhotoClassesViewModel()
        {
            _photoClassesRequester = new PhotoClassesRequester();
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
                CountTotalItems = (await _photoClassesRequester.GetCountPhotoClassesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new PhotoClassesFilters();

            await ResetPaginationAsync();
            await GetNamesPhotoClassesAsync();
            await SearchAsync();
        }

        private async Task GetNamesPhotoClassesAsync()
        {
            NamesPhotoClasses = new ObservableCollection<string>((await _photoClassesRequester.GetNamesPhotoClassesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            PhotoClasses = new ObservableCollection<PhotoClass>((await _photoClassesRequester.GetPhotoClassesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var photoClasses = await _photoClassesRequester.GetPhotoClassesAsync(Filters);

                    foreach (var photoClass in photoClasses)
                    {
                        PhotoClasses.Add(photoClass);
                    }
                }
            }
        }
    }
}
