using StudentManagementSystem.Model;

namespace StudentManagementSystem.Repository.Interface
{
    public interface IUserRepo
    {
        public int Loginrepo(string _username, string _password);

        public int Registerrepo(string _username, string _password);
    }
}
