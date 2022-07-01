using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Atheneum.Dto.Auth
{
    [LoginPassNotTheSame]
    public class LoginDto
    {
        [Required] 
        [MinLength(3)]
        [MaxLength(20)] 
        public string Login { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)] 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPhone => string.IsNullOrWhiteSpace(Login) ? false : Regex.IsMatch(Login, @"^\+[0-9]{11}$");

        public bool IsEmail => string.IsNullOrWhiteSpace(Login) ? false : Regex.IsMatch(Login, @".+@.+\..+");
    }

    internal class LoginPassNotTheSame : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (LoginDto) validationContext.ObjectInstance;

            return model.Login == model.Password
                ? new ValidationResult(ErrorMessage = "Логин и пароль не должны совпадать")
                : ValidationResult.Success;
        }
    }
}