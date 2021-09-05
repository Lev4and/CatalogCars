using DevExpress.Mvvm;
using System;

namespace CatalogCars.DesktopApplication.Services
{
    public class ImportProgressAnalyzer : BindableBase
    {
        public TimeSpan TimeLeft { get; private set; }

        public ImportProgressAnalyzer()
        {
            Reset();
        }

        public void Reset()
        {
            TimeLeft = new TimeSpan();
        }

        public void OnCompletedImportItem(DateTime startDateTime, double countImportedItems, double countTotalItems)
        {
            TimeLeft = new TimeSpan(0, 0, 0, 0, (int)((DateTime.Now - startDateTime).TotalMilliseconds / countImportedItems *
                (countTotalItems - countImportedItems)));
        }
    }
}
