using StudentManagementSystem.Model;

namespace StudentManagementSystem.Operation.Interface
{
    public interface IUserOps
    {
        public int LoginOps(string _username, string _password);

        public int RegisterOps(string _username, string _password);
    }
}