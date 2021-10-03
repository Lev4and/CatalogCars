using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class BodyTypesViewModel : BindableBase
    {
        private readonly BodyTypesRequester _bodyTypesRequester;
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;

        public Pagination Pagination { get; set; }

        public BodyTypesFilters Filters { get; set; }

        public Pagination BodyTypeGroupsPagination { get; set; }

        public BodyTypeGroupsFilters BodyTypeGroupsFilters { get; set; }

        public ObservableCollection<string> NamesBodyTypes { get; set; }

        public ObservableCollection<Entities.BodyType> BodyTypes { get; set; }

        public ObservableCollection<Entities.BodyTypeGroup> BodyTypeGroups { get; set; }

        public ICommand BodyTypeGroupsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return BodyTypeGroupsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesBodyTypesAsync();
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

        public BodyTypesViewModel()
        {
            _bodyTypesRequester = new BodyTypesRequester();
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
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
                CountTotalItems = (await _bodyTypesRequester.GetCountBodyTypesAsync(Filters))
            };
        }

        private async Task ResetBodyTypeGroupsPaginationAsync()
        {
            BodyTypeGroupsPagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _bodyTypeGroupsRequester.GetCountBodyTypeGroupsAsync(BodyTypeGroupsFilters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new BodyTypesFilters();
            BodyTypeGroupsFilters = new BodyTypeGroupsFilters();

            await ResetPaginationAsync();
            await ResetBodyTypeGroupsPaginationAsync();

            await GetNamesBodyTypesAsync();

            await SearchAsync();
            await SearchBodyTypeGroupsAsync();
        }

        private async Task GetNamesBodyTypesAsync()
        {
            NamesBodyTypes = new ObservableCollection<string>((await _bodyTypesRequester.GetNamesBodyTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            BodyTypes = new ObservableCollection<Entities.BodyType>((await _bodyTypesRequester.GetBodyTypesAsync(Filters)).ToList());
        }

        private async Task SearchBodyTypeGroupsAsync()
        {
            BodyTypeGroupsFilters.ResetForSearch();

            await ResetBodyTypeGroupsPaginationAsync();

            BodyTypeGroups = new ObservableCollection<Entities.BodyTypeGroup>((await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(BodyTypeGroupsFilters)).ToList());
        }

        private async Task BodyTypeGroupsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (BodyTypeGroupsPagination.NumberPage < BodyTypeGroupsPagination.MaxNumberPage)
                {
                    BodyTypeGroupsFilters.NumberPage += 1;
                    BodyTypeGroupsPagination.NumberPage += 1;

                    var bodyTypeGroups = await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(BodyTypeGroupsFilters);

                    foreach (var bodyTypeGroup in bodyTypeGroups)
                    {
                        BodyTypeGroups.Add(bodyTypeGroup);
                    }
                }
            }
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var bodyTypes = await _bodyTypesRequester.GetBodyTypesAsync(Filters);

                    foreach (var bodyType in bodyTypes)
                    {
                        BodyTypes.Add(bodyType);
                    }
                }
            }
        }
    }
}
