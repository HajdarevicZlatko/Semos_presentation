using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Managment.Api.Models;
using User.Managment.Api.Models.Authentication.SignUp;

namespace User.Managment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser, string role) 
        {
            //Check user exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null) 
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User exists" });
            }


            //Add user in database

            IdentityUser user = new IdentityUser
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username,
                PasswordHash = Guid.NewGuid().ToString(),
                
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "User created" });
            }
            else 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Error creating user" });
            }

            //Assign a role

        }
    }
}
