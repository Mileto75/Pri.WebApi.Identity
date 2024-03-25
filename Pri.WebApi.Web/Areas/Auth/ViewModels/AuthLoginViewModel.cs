using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Web.Areas.Auth.ViewModels
{
    public class AuthLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
