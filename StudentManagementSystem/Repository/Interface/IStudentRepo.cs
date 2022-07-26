using StudentManagementSystem.Model;

namespace StudentManagementSystem.Repository.Interface
{
    public interface IStudentRepo
    {
        public List<StudentModel> GetStudentRepo();
        public StudentModel GetStudentByIdRepo(int Student_Id);
        public StudentModel ByNameRepo(String Student_Name);
        public int SaveStudentRepo(StudentModel studentmodel);
        public int DeleteStudentRepo(int Student_Id);

    }
}