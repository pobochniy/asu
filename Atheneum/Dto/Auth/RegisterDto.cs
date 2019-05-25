using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.Auth
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
