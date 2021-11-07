namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class SaveResult<T>
    {
        public T Result { get; set; }
        
        public string Message { get; set; }

        public SaveResultStatus Status { get; set; }
    }
}
