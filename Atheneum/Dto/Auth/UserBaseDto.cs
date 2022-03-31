using System.ComponentModel.DataAnnotations;

namespace Atheneum.Dto.Auth
{
    public class UserBaseDto
    {
        [Required]
        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
