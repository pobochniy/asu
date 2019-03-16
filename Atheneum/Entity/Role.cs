using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity.Identity
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<UserInRole> UserInRoles { get; set; }

        public Role()
        {
            UserInRoles = new List<UserInRole>();
        }
    }
}
