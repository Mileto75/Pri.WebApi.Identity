using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Api.Dtos.Request
{
    public class AuthRegisterDto : AuthLoginDto
    {
        [Compare("Password")]
        public string RepeatPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
