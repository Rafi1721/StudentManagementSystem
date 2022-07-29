using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Model
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(?=.*_[A-Za-z])(?=.*_)[A-Za-z]{8,15}$")]
        public string Password { get; set; } = string.Empty;
    }
}