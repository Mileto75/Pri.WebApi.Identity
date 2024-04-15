using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Web.Areas.Auth.ViewModels
{
    public class AuthRegisterViewModel : AuthLoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
