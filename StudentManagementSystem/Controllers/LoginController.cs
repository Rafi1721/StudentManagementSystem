using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentManagementSystem.Model;
using StudentManagementSystem.Authentication;
using StudentManagementSystem.Operation.Interface;
using StudentManagementSystem.Helpers.Interface;

namespace StudentManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthentication jwtAuthenticationManager;
        private readonly IUserOps _userops;
        private readonly IAPIResponseHelper responseHelper;


        public LoginController(JwtAuthentication jwtAuthenticationManager, IUserOps userops, IAPIResponseHelper responseHelper)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this._userops = userops;
            this.responseHelper = responseHelper;

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

        [HttpPost("")]
        public IActionResult Register([FromBody] User usr)
        {
            var response = _userops.RegisterOps(usr.UserName, usr.Password);
            return responseHelper.CreateResponse(response);
        }
    }
}
