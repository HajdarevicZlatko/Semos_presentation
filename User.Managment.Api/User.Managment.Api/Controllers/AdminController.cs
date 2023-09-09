using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Management.Service.Models;
using User.Managment.Api.Models;

namespace User.Managment.Api.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AdminFunctionality()
        {
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Entered" });
        }
    }
}
