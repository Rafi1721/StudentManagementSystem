using StudentManagementSystem.Model;

namespace StudentManagementSystem.Operation.Interface
{
    public interface IStudentOps
    {
        public List<StudentModel> GetStudentOps();
        public StudentModel GetStudentByIdOps(int Student_Id);
       public StudentModel ByNameOps(String Student_Name);
        public int SaveStudentOps(StudentModel studentmodel);
        public int DeleteStudentOps(int Student_Id);
    }
}
