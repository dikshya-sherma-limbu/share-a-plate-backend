using Microsoft.AspNetCore.Mvc;

namespace share_a_plate_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        public IActionResult Login()
        {

            return Ok();
        }
    }
}
