using CatalogCars.Model.Database.AuxiliaryTypes;
using Entities = CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Linq;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class ModelsViewModel : BindableBase
    {
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;

        public Pagination Pagination { get; set; }

        public ModelsFilters Filters { get; set; }

        public MarksFilters MarksFilters { get; set; }

        public Pagination MarksPagination { get; set; }

        public ObservableCollection<string> NamesModels { get; set; }

        public ObservableCollection<Entities.Mark> Marks { get; set; }

        public ObservableCollection<Entities.Model> Models { get; set; }

        public ICommand MarksScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return MarksLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesModelsAsync();
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

        public ModelsViewModel()
        {
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
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
                CountTotalItems = (await _modelsRequester.GetCountModelsAsync(Filters))
            };
        }

        private async Task ResetMarksPaginationAsync()
        {
            MarksPagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _marksRequester.GetCountMarksAsync(MarksFilters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new ModelsFilters();
            MarksFilters = new MarksFilters();

            await ResetPaginationAsync();
            await ResetMarksPaginationAsync();

            await GetNamesModelsAsync();

            await SearchAsync();
            await SearchMarksAsync();
        }

        private async Task GetNamesModelsAsync()
        {
            NamesModels = new ObservableCollection<string>((await _modelsRequester.GetNamesModelsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Models = new ObservableCollection<Entities.Model>((await _modelsRequester.GetModelsAsync(Filters)).ToList());
        }

        private async Task SearchMarksAsync()
        {
            MarksFilters.ResetForSearch();

            await ResetMarksPaginationAsync();

            Marks = new ObservableCollection<Entities.Mark>((await _marksRequester.GetMarksAsync(MarksFilters)).ToList());
        }

        private async Task MarksLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (MarksPagination.NumberPage < MarksPagination.MaxNumberPage)
                {
                    MarksFilters.NumberPage += 1;
                    MarksPagination.NumberPage += 1;

                    var marks = await _marksRequester.GetMarksAsync(MarksFilters);

                    foreach (var mark in marks)
                    {
                        Marks.Add(mark);
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

                    var models = await _modelsRequester.GetModelsAsync(Filters);

                    foreach (var model in models)
                    {
                        Models.Add(model);
                    }
                }
            }
        }
    }
}
