using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Helpers.Interface;
using StudentManagementSystem.Model;
using StudentManagementSystem.Operation.Interface;
using Microsoft.AspNetCore.Authorization;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentOps _StudentOps;
        private readonly IAPIResponseHelper responseHelper;


        public StudentController(IStudentOps StudentOps, IAPIResponseHelper responseHelper)
        {
            this._StudentOps = StudentOps;
            this.responseHelper = responseHelper;
        }

        [Authorize]
        [HttpGet("")]
        public IActionResult GetStudent()
        {
            var response = _StudentOps.GetStudentOps();
            return responseHelper.CreateResponse(response);
        }

        [Authorize]
        [HttpGet("{Student_Id:int}")]
        public IActionResult GetStudentById([FromRoute] int Student_Id)
        {
            if (Student_Id < 1)
            {
                return BadRequest();
            }
            var response = _StudentOps.GetStudentByIdOps(Student_Id);
            return responseHelper.CreateResponse(response);
        }

        [Authorize]
        [HttpGet("Student_Name")]
        public IActionResult ByName([FromQuery] string Student_Name)
        {
            if (string.IsNullOrWhiteSpace(Student_Name))
            {
                return BadRequest();
            }
            var response = _StudentOps.ByNameOps(Student_Name);
            return responseHelper.CreateResponse(response);
        }

        [Authorize]
        [HttpPost("")]
        public IActionResult SaveStudent([FromBody] StudentModel studentmodel)
        {
            if (string.IsNullOrWhiteSpace(studentmodel.Student_Name))
            {
                return BadRequest();
            }
            var response = _StudentOps.SaveStudentOps(studentmodel);
            return responseHelper.CreateResponse(response);
        }

        [Authorize]
        [HttpDelete("{Student_Id}")]
        public IActionResult Delete([FromRoute] int Student_Id)
        {
            if (Student_Id < 1)
            {
                return BadRequest();
            }
            var response = _StudentOps.DeleteStudentOps(Student_Id);
            return responseHelper.CreateResponse(response);
        }
    }
}