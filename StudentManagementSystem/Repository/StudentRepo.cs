using MySql.Data.MySqlClient;
using StudentManagementSystem.Model;
using StudentManagementSystem.Repository.Interface;
using System.Data;

namespace StudentManagementSystem.Repository
{
    public class StudentRepo : IStudentRepo
    {

        private readonly ILogger<StudentRepo> logger;
        private IConfiguration _Configuration;

        public StudentRepo(IConfiguration configuration, ILogger<StudentRepo> logger)
        {
            this.logger = logger;
            _Configuration = configuration;
        }

        public List<StudentModel> GetStudentRepo()
        {

            try
            {
                var studentList = new List<StudentModel>();
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGet_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StudentModel studentModel = new StudentModel();
                    studentModel.Student_Id = Convert.ToInt32(reader["Student_Id"]);
                    studentModel.Student_Name = reader["Student_Name"].ToString();
                    studentList.Add(studentModel);
                }
                con.Close();
                return studentList;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }
        public StudentModel GetStudentByIdRepo(int studentId)
        {

            try
            {

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGetById_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_studentId", studentId);
                var reader = cmd.ExecuteReader();
                StudentModel studentModel = new StudentModel();
                if (reader.Read())
                {

                    studentModel.Student_Id = Convert.ToInt32(reader["Student_Id"]);
                    studentModel.Student_Name = reader["Student_Name"].ToString();
                }
                con.Close();
                return studentModel;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public StudentModel ByNameRepo(string StudentName)
        {

            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGetByName_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_StudentName", StudentName);
                var reader = cmd.ExecuteReader();
                StudentModel student = new StudentModel();
                if (reader.Read())
                {
                    student.Student_Id = Convert.ToInt32(reader["Student_Id"]);
                    student.Student_Name = reader["Student_Name"].ToString();
                }
                con.Close();
                return student;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }
        public int SaveStudentRepo(StudentModel studentmodel)
        {


            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentInsert_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_StudentName", studentmodel.Student_Name);
                cmd.Parameters.AddWithValue("_studentId", studentmodel.Student_Id);
                var Student_Id = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
                return Student_Id;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }

        }

        public int DeleteStudentRepo(int studentId)
        {

            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentDelete_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_studentId", studentId);
                var res = Convert.ToInt32(cmd.ExecuteScalar());


                con.Close();
                return res;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }

        }
    }
}
