using CatalogCars.DesktopApplication.Services;
using DevExpress.Mvvm;
using Microsoft.Win32;
using System.Windows.Input;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class ImportCarsViewModel : BindableBase
    {
        private string[] _jsonFilesPath;

        public ImportCars ImportCars { get; set; }

        public ImportCarsViewModel()
        {
            ImportCars = new ImportCars();
        }

        public ICommand BrowseFiles => new DelegateCommand(() =>
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = true;

            fileDialog.Title = "Выберите файлы JSON";
            fileDialog.Filter = "Json files (*.json)|*.json";

            if (fileDialog.ShowDialog() == true)
            {
                _jsonFilesPath = fileDialog.FileNames;
            }

        }, () => ImportCars.IsRunning == false);

        public ICommand StartImport => new DelegateCommand(() =>
        {
            ImportCars.Start(_jsonFilesPath);
        }, () => (_jsonFilesPath != null ? _jsonFilesPath.Length > 0 : false) && !ImportCars.IsRunning);

        public ICommand StopImport => new DelegateCommand(() =>
        {
            ImportCars.Stop();
        }, () => ImportCars.IsRunning == true);
    }
}
