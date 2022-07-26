using StudentManagementSystem.Model;
using StudentManagementSystem.Operation.Interface;
using StudentManagementSystem.Repository.Interface;

namespace StudentManagementSystem.Operation
{
    public class StudentOps : IStudentOps
    {

        private readonly IStudentRepo _studentRepo;
        private readonly ILogger<StudentOps> _logger;
        public StudentOps(IStudentRepo studentRepo, ILogger<StudentOps> logger)

        {
            this._studentRepo = studentRepo;
            this._logger = logger;

        }

        public List<StudentModel> GetStudentOps()
        {
            return _studentRepo.GetStudentRepo();
        }
        public StudentModel GetStudentByIdOps(int Student_Id)
        {
            return _studentRepo.GetStudentByIdRepo(Student_Id);
        }
        public StudentModel ByNameOps(String Student_Name)
        {
            return _studentRepo.ByNameRepo(Student_Name);
        }
        public int SaveStudentOps(StudentModel studentmodel)
        {
            return _studentRepo.SaveStudentRepo(studentmodel);
        }
        public int DeleteStudentOps(int Student_Id)
        {
            return _studentRepo.DeleteStudentRepo(Student_Id);
        }
    }
}
