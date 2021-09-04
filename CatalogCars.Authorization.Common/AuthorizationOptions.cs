using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CatalogCars.Authorization.Common
{
    public static class AuthorizationOptions
    {
        public static int TokenLifetime => 3600;

        public static string Secret => "SecretKey123456789+-";

        public static string Issuer => "AuthorizationServer";

        public static string Audience => "ResourceServer";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
