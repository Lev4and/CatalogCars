namespace CatalogCars.Model.Common
{
    public class DbConfig
    {
        public static string ConnectionString => "Data Source=DESKTOP-9CDGA5B;Initial Catalog=CatalogCars;User ID=sa;" +
            "Password=sa;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
    }
}
