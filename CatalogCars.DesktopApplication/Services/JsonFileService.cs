using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace CatalogCars.DesktopApplication.Services
{
    public class JsonFileService
    {
        public T DeserializeJsonFile<T>(string jsonFilePath)
        {
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                if (File.Exists(jsonFilePath))
                {
                    using (var fileStream = new FileStream(jsonFilePath, FileMode.Open))
                    {
                        var buffer = new byte[fileStream.Length];

                        fileStream.Read(buffer, 0, buffer.Length);

                        return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(buffer));
                    }
                }
            }

            return default(T);
        }
    }
}
