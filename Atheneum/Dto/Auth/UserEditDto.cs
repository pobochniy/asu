using System;

namespace Atheneum.Dto.Auth
{
    public class UserEditDto : UserBaseDto
    {
        public Guid? Id { get; set; }

        public string Comment { get; set; }
    }
}
