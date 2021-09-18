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
    public class GenerationsViewModel : BindableBase
    {
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;
        private readonly GenerationsRequester _generationsRequester;
        private readonly PriceSegmentsRequester _priceSegmentsRequester;

        public double MinYearFrom { get; set; }

        public double MaxYearFrom { get; set; }

        public Pagination Pagination { get; set; }

        public MarksFilters MarksFilters { get; set; }

        public Pagination MarksPagination { get; set; }

        public GenerationsFilters Filters { get; set; }

        public ModelsFilters ModelsFilters { get; set; }

        public Pagination ModelsPagination { get; set; }

        public ObservableCollection<string> NamesGenerations { get; set; }

        public ObservableCollection<Entities.Mark> Marks { get; set; }

        public ObservableCollection<Entities.Model> Models { get; set; }

        public ObservableCollection<Entities.Generation> Generations { get; set; }

        public ObservableCollection<Entities.PriceSegment> PriceSegments { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public ICommand ModelsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return ModelsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand MarksScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return MarksLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SelectedMarksChanged => new AsyncCommand(() =>
        {
            return SearchModelsAsync();
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesGenerationsAsync();
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

        public GenerationsViewModel()
        {
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
            _generationsRequester = new GenerationsRequester();
            _priceSegmentsRequester = new PriceSegmentsRequester();

            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" }
            };
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
                CountTotalItems = (await _generationsRequester.GetCountGenerationsAsync(Filters))
            };
        }

        private async Task ResetMarksPaginationAsync()
        {
            MarksPagination = new Pagination()
            {
                NumberPage = MarksFilters.NumberPage,
                ItemsPerPage = MarksFilters.ItemsPerPage,
                CountTotalItems = (await _marksRequester.GetCountMarksAsync(MarksFilters))
            };
        }

        private async Task ResetModelsPaginationAsync()
        {
            ModelsPagination = new Pagination()
            {
                NumberPage = ModelsFilters.NumberPage,
                ItemsPerPage = ModelsFilters.ItemsPerPage,
                CountTotalItems = (await _modelsRequester.GetCountModelsOfMarksAsync(ModelsFilters))
            };
        }

        private async Task ResetAsync()
        {
            MinYearFrom = (double) await _generationsRequester.GetMinYearFromGenerationAsync();
            MaxYearFrom = (double) await _generationsRequester.GetMaxYearFromGenerationAsync();

            PriceSegments = new ObservableCollection<Entities.PriceSegment>(await 
                _priceSegmentsRequester.GetPriceSegmentsAsync());

            Filters = new GenerationsFilters();

            Filters.RangeYearFrom.From = (int)MinYearFrom;
            Filters.RangeYearFrom.To = (int)MaxYearFrom;

            MarksFilters = new MarksFilters();
            ModelsFilters = new ModelsFilters();

            await ResetPaginationAsync();
            await ResetMarksPaginationAsync();
            await ResetModelsPaginationAsync();

            await GetNamesGenerationsAsync();

            await SearchAsync();
            await SearchMarksAsync();
            await SearchModelsAsync();
        }

        private async Task GetNamesGenerationsAsync()
        {
            NamesGenerations = new ObservableCollection<string>((await _generationsRequester.GetNamesGenerationsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Generations = new ObservableCollection<Entities.Generation>((await _generationsRequester.GetGenerationsAsync(Filters)).ToList());
        }

        private async Task SearchMarksAsync()
        {
            MarksFilters.ResetForSearch();

            await ResetMarksPaginationAsync();

            Marks = new ObservableCollection<Entities.Mark>((await _marksRequester.GetMarksAsync(MarksFilters)).ToList());
        }

        private async Task SearchModelsAsync()
        {
            ModelsFilters.ResetForSearch();
            ModelsFilters.MarksIds = Filters.MarksIds;

            await ResetModelsPaginationAsync();

            Models = new ObservableCollection<Entities.Model>((await _modelsRequester.GetModelsOfMarksAsync(ModelsFilters)).ToList());
        }

        private async Task ModelsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (ModelsPagination.NumberPage < ModelsPagination.MaxNumberPage)
                {
                    ModelsFilters.NumberPage += 1;
                    ModelsPagination.NumberPage += 1;
                    ModelsFilters.MarksIds = Filters.MarksIds;

                    var models = await _modelsRequester.GetModelsOfMarksAsync(ModelsFilters);

                    foreach (var model in models)
                    {
                        Models.Add(model);
                    }
                }
            }
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

                    var generations = await _generationsRequester.GetGenerationsAsync(Filters);

                    foreach (var generation in generations)
                    {
                        Generations.Add(generation);
                    }
                }
            }
        }
    }
}
