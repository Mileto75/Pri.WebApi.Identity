using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Api.Dtos.Request
{
    public class AuthLoginDto
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
