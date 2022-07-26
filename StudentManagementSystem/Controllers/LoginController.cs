using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public LoginController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpPost]
        [AllowAnonymous()]
        public IActionResult Authorize([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.UserName, usr.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(token);
        }

        [HttpDelete]
        public IActionResult TestRoute()
        {
            return Ok("Authorized");
        }
    }
}
