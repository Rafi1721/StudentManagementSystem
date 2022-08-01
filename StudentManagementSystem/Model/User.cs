using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Model
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string Password { get; set; } = string.Empty;
    }
}