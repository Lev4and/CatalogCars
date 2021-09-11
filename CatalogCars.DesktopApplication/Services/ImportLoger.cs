using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace CatalogCars.DesktopApplication.Services
{
    public class ImportLoger : BindableBase
    {
        public ObservableCollection<string> Log { get; set; }

        public ImportLoger()
        {
            Reset();
        }

        public void Reset()
        {
            Log = new ObservableCollection<string>();
        }

        public void OnStartedImport()
        {
            Log.Add($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][Импорт товаров] Импорт начался");
        }

        public void OnCompletedImport()
        {
            Log.Add($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][Импорт объявлений] Импорт завершен");
        }

        public void OnCompletedImportItem(double countImportedItems, double countTotalItems)
        {
            Log.Add($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}][Импорт объявлений] Сохранен элемент. Текущий прогресс: {countImportedItems}/{countTotalItems}");
        }
    }
}
