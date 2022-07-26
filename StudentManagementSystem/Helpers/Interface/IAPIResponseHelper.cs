using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Helpers.Interface
{
    public interface IAPIResponseHelper
    {
        public IActionResult CreateResponse(dynamic result);
        public IActionResult GetFile(byte[] data, string fileName, string media);
        IActionResult GetFile(object result, string filename, string v);
    }
}
