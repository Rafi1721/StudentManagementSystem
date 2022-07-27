using StudentManagementSystem.Operation.Interface;
using StudentManagementSystem.Repository.Interface;

namespace StudentManagementSystem.Operation
{
    public class UserOps : IUserOps
    {
        private readonly ILogger _logger;
        private readonly IUserRepo _UserRepo;
        public UserOps(IUserRepo userRepo, IConfiguration configuration,
                            ILogger<UserOps> logger)
        {
            this._logger = logger;
            this._UserRepo = userRepo;
        }
        public int LoginOps(string _username, string _password)
        {
            return _UserRepo.Loginrepo(_username, _password);
        }
    }
}
