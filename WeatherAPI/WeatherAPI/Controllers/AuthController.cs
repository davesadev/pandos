using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using System.Collections.Generic;
using System.Security.Claims;
using WeatherAPI.Identity;
using Microsoft.AspNetCore.Identity;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult>Login(UserDto userDto)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userDto.UserName);

            if (user is null)
                return NotFound();
            bool result = await _userManager.CheckPasswordAsync(user, userDto.Password);
            if (!result)
                return Ok(new { result = false });
            
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Csun590@8:59PMS#cretKey"));
            SigningCredentials signingCreds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken tokenOptions = new(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCreds
            ); 
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }

        [HttpPost]
        [Route("Create")]

        // what creates the user on backend, takes name and pass from angular front end
        public async Task<IActionResult> Create(string UserName, string Password)
        {
            ApplicationUser user = new()  // creates user object
            {
                UserName = UserName,
                Email = $"{UserName}@gmail.com",
                EmailConfirmed = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, Password);  // creates user
            return Ok(result);
        }

//        public IActionResult Index()
//        {return View(); }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
