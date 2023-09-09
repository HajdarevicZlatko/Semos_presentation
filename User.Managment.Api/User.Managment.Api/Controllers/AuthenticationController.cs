using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Management.Service.Services;
using User.Management.Service.Models;
using User.Managment.Api.Models;
using User.Managment.Api.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using User.Managment.Api.Models.Authentication.LogIn;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace User.Managment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser, string role) 
        {
            #region Check user existuser exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User exists" });
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "This role do not exist" });
            } 
            #endregion

            #region Add user in database
            //Add user in database

            IdentityUser user = new IdentityUser
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,
                PasswordHash = Guid.NewGuid().ToString(),

            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Error creating user: {result.Errors.First().Description}" });
            } 
            #endregion

            #region Assign a role
            //Assign a role
            var resultRole = await _userManager.AddToRoleAsync(user, role);
            if (!resultRole.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role adding failed" });
            } 
            #endregion

            #region Add Token to verified email
            //Add Token to verified email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
            _emailService.SendEmail(message);
            #endregion

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = $"User created and Email send to: {user.Email}" });

        }

        [HttpGet]
        public  IActionResult TestEmail() 
        {
            var message = new Message(new string[] { "zlatko.hajdarevic@gmail.com" }, "Test", "Test")   ;
            _emailService.SendEmail(message);
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email sended" });
        }

        [HttpGet("ConfirmEmail")]

        public async Task<IActionResult> ConfirmEmail(string token, string email) 
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) 
            { 
            var result = await _userManager.ConfirmEmailAsync(user,token);
            if (result.Succeeded) 
            {
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Email sent" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Confirm error:{result.Errors.First().Description}" });
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "No user with email" });

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            //Checking user
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user == null) return Unauthorized();

            //Checking password 
            bool checkPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if(!checkPassword) return Unauthorized();

            var authClaims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles) 
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = GetToken(authClaims);

            return Ok(
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
                );

            //we add row to the claim
            //return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Login OK" });
        }

        private JwtSecurityToken GetToken(List<Claim> claims) {

            var autSingInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials:new SigningCredentials(autSingInKey,SecurityAlgorithms.HmacSha256)
                ); ;
            return token;

        }


    }
}
