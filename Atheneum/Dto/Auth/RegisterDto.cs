using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.Account
{
    public class RegisterDto : LoginDto
    {
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
