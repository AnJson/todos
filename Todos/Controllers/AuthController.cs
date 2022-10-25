using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todos.Model.Auth;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            // Implement.
        }
    }
}
