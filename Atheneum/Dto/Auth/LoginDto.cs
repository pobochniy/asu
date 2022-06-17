using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Atheneum.Dto.Auth
{
    public class LoginDto
    {
        [Required]
        [MinLength(3)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPhone => string.IsNullOrWhiteSpace(Login) ? false : Regex.IsMatch(Login, @"^\+[0-9]{11}$");

        public bool IsEmail => string.IsNullOrWhiteSpace(Login) ? false : Regex.IsMatch(Login, @".+@.+\..+");
    }
}
