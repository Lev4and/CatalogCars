using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Authorization.Models
{
    public class LoginViewModel
    {
        [Required]
        public string EmailOrLogin { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
