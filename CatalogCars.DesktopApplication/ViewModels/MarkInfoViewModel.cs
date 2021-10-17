using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class MarkInfoViewModel : BindableBase
    {
        private readonly MarksRequester _marksRequester;
        private readonly ModelsRequester _modelsRequester;

        public Mark Mark { get; set; }

        public string[] LabelsPopularityMark { get; set; }

        public SeriesCollection SeriesPopularityMark { get; set; }

        public SeriesCollection SeriesPopularityModels { get; set; }

        public ObservableCollection<PopularityMark> PopularityMark { get; set; }

        public ObservableCollection<PopularityModels> PopularityModels { get; set; }

        public ICommand Loaded => new AsyncCommand<Guid>((markId) =>
        {
            return LoadedAsync(markId);
        });

        public MarkInfoViewModel()
        {
            _marksRequester = new MarksRequester();
            _modelsRequester = new ModelsRequester();
        }

        private async Task LoadedAsync(Guid markId)
        {
            Mark = await _marksRequester.GetMarkAsync(markId);

            PopularityMark = new ObservableCollection<PopularityMark>(await 
                _marksRequester.GetPopularityMarkAsync(markId));
            PopularityModels = new ObservableCollection<PopularityModels>(await 
                _modelsRequester.GetPopularityModelsOfMarkAsync(markId));

            LabelsPopularityMark = PopularityMark.Select(popularityMark => 
                popularityMark.DateTime.ToString("dd-MM-yyyy")).ToArray();

            SeriesPopularityMark = new SeriesCollection()
            {
                new LineSeries()
                {
                    Title = "Публикации",
                    Values = new ChartValues<int>(PopularityMark.Select(popularityMark =>
                        popularityMark.Count).ToArray())
                }
            };

            SeriesPopularityModels = new SeriesCollection();

            foreach(var popularityModel in PopularityModels)
            {
                SeriesPopularityModels.Add(new PieSeries
                {
                    Title = popularityModel.ModelName,
                    Values = new ChartValues<int>() { popularityModel.Count }
                });
            }
        }
    }
}
