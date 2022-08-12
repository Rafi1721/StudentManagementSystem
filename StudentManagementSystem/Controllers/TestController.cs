using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{
    [Route("Hello World")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Display()
        {
            return "Hello World!";

        }
    }
}
    

