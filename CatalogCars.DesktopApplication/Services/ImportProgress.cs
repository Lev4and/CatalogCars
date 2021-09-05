using DevExpress.Mvvm;

namespace CatalogCars.DesktopApplication.Services
{
    public class ImportProgress : BindableBase
    {
        private double _countTotalItems;
        private double _countImportedItems;

        public double CountTotalItems
        {
            get { return _countTotalItems; }
            protected set
            {
                _countTotalItems = value;

                Recalculate();
            }
        }

        public double CountImportedItems
        {
            get { return _countImportedItems; }
            private set
            {
                _countImportedItems = value;

                Recalculate();
            }
        }

        public double Progress { get; private set; }

        public ImportProgress()
        {
            Reset();
        }

        private void Recalculate()
        {
            if (CountTotalItems > 0)
            {
                Progress = CountImportedItems / CountTotalItems * 100.0;
            }
            else
            {
                Progress = 0;
            }
        }

        public void Reset()
        {
            Progress = 0;

            CountTotalItems = 0;
            CountImportedItems = 0;
        }

        public void OnGotItems(int countItems)
        {
            CountTotalItems = countItems;
        }

        public void OnCompletedImportItem()
        {
            CountImportedItems += 1;
        }
    }
}
