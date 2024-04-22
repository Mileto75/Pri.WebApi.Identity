using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pri.WebApi.Api.Dtos.Request;
using Pri.WebApi.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Pri.WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginDto authLoginDto)
        {
            //check user credentials
            var result = await _signInManager
                .PasswordSignInAsync(authLoginDto.Username,authLoginDto.Password
                ,false,false);
            if(result.Succeeded)
            {
                //get the user claims
                    //get the user
                var user = await _userManager.FindByNameAsync(authLoginDto.Username);
                    //get the claims
                var claims = await _userManager.GetClaimsAsync(user);
                //generate the token
                var issuer = _configuration.GetValue<string>("JWTConfiguration:Issuer");
                var audience = _configuration.GetValue<string>("JWTConfiguration:Audience");
                //var expirationDate = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JWTConfiguration:ExpirationDays"));
                var expirationDate = DateTime.UtcNow.AddDays(7);
                var secretKey = _configuration.GetValue<string>("JWTConfiguration:UserSecret");
                var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var signinCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
                //create the token
                var token = new JwtSecurityToken(
                    audience: audience,
                    issuer: issuer,
                    notBefore: DateTime.UtcNow,
                    expires: expirationDate,
                    signingCredentials: signinCredentials
                    );
                //serialize the token
                var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
                //return the token
                return Ok(serializedToken);
            }
            return BadRequest("Wrong credentials");
        }
    }
}
