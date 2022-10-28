using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Todos.Model.Auth;
using Todos.Services;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthService AuthService { get; }

        public AuthController(AuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Auth>> Register(AuthDto request)
        {
            /*
            try{
                Auth user = AuthService.Register(request);
                return Ok("Success!"); // Return json-formatted user. With jwt?
            } catch (Exception e)
            {
                // Fix this exceptiontype.
                return BadRequest(e.Message);
            }
            */
            return Ok("Success!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AuthDto request)
        {
            /*
            try
            {
                await AuthService.Login(request);
                return Ok("Logged in!"); // Return json-formatted user. With jwt?
            } catch (Exception e)
            {
                // Fix this exceptiontype.
                return BadRequest(e.Message);
            }
            */

            /*
            if (user.Username != request.username)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request.password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            */
               
            return Ok("Success!");
            
        }
    }
}
