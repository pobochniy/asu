using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Atheneum.Dto.Account
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPhone => Regex.IsMatch(Login, @"^\+[0-9]{11}$");

        public bool IsEmail => Regex.IsMatch(Login, @".+@.+\..+");
    }
}
