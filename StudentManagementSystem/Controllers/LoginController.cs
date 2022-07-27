using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentManagementSystem.Model;
using StudentManagementSystem.Authentication;
using StudentManagementSystem.Operation.Interface;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthentication jwtAuthenticationManager;
        private readonly IUserOps _userops;


        public LoginController(JwtAuthentication jwtAuthenticationManager, IUserOps userops)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this._userops = userops;
        }

        [HttpPost]
        [AllowAnonymous()]
        public IActionResult Authorize([FromBody] User usr)
        {
            int res = _userops.LoginOps(usr.UserName, usr.Password);
            if (res == 1)
            {
                var token = jwtAuthenticationManager.Authenticate(usr.UserName, usr.Password);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(token);
                }
            }
            else
                return null;
        }
    }
}
