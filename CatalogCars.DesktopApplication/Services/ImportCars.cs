using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogCars.DesktopApplication.Services
{
    public class ImportCars : BindableBase
    {
        private readonly ImportRequester _importRequester;
        private readonly JsonFileService _jsonFileService;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        public event Action<int> OnGotItems;

        public event Action OnStartedImport;
        public event Action OnCompletedImport;
        public event Action OnCompletedImportItem;

        public bool IsRunning { get; private set; }

        public ImportLoger Loger { get; }

        public ImportTimer Timer { get; }

        public ImportProgress Progress { get; }

        public ImportProgressAnalyzer ProgressAnalyzer { get; }

        public ImportCars()
        {
            _importRequester = new ImportRequester();
            _jsonFileService = new JsonFileService();

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            IsRunning = false;

            Loger = new ImportLoger();
            Timer = new ImportTimer();
            Progress = new ImportProgress();
            ProgressAnalyzer = new ImportProgressAnalyzer();
        }

        private void Reset()
        {
            IsRunning = false;
        }

        [AsyncCommand(UseCommandManager = false)]
        public async Task Start(string[] jsonFilesPath)
        {
            Timer.Start();
            Loger.Reset();

            if (jsonFilesPath != null ? jsonFilesPath.Length > 0 : false)
            {
                await ImportAsync(jsonFilesPath, _cancellationToken);
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();

            Reset();

            Timer.Stop();
            Progress.Reset();
            ProgressAnalyzer.Reset();
        }

        private async Task ImportAsync(string[] jsonFilesPath, CancellationToken cancellationToken)
        {
            IsRunning = true;

            OnGotItems += (countItems) => Progress.OnGotItems(countItems);

            OnStartedImport += () => Loger.OnStartedImport();
            OnCompletedImport += () =>
            {
                Timer.Stop();
                Loger.OnCompletedImport();
            };


            OnCompletedImportItem += () =>
            {
                Progress.OnCompletedImportItem();
                Loger.OnCompletedImportItem(Progress.CountImportedItems, Progress.CountTotalItems);
                ProgressAnalyzer.OnCompletedImportItem(Timer.StartDateTime, Progress.CountImportedItems, Progress.CountTotalItems);
            };

            OnGotItems?.Invoke(jsonFilesPath.Length);

            OnStartedImport?.Invoke();

            foreach (var jsonFilePath in jsonFilesPath)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    var result = _jsonFileService.DeserializeJsonFile<Result>(jsonFilePath);

                    if(result != null ? result.Announcements != null : false)
                    {
                        foreach (var announcement in result.Announcements)
                        {
                            if (await _importRequester.SaveAnnouncementAsync(announcement))
                            {

                            }
                        }

                        OnCompletedImportItem?.Invoke();
                    }
                }
                else
                {
                    break;
                }
            }

            OnCompletedImport?.Invoke();

            OnGotItems -= (countItems) => Progress.OnGotItems(countItems);

            OnStartedImport -= () => Loger.OnStartedImport();
            OnCompletedImport -= () => Loger.OnCompletedImport();
            OnCompletedImportItem -= () => Progress.OnCompletedImportItem();

            IsRunning = false;
        }
    }
}
