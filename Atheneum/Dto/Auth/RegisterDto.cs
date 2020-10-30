using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.Auth
{
    public class RegisterDto : UserBaseDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
