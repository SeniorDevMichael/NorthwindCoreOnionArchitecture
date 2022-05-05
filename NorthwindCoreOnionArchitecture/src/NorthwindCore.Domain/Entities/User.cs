using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindCore.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            LnkUserRoles = new HashSet<LnkUserRole>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<LnkUserRole> LnkUserRoles { get; set; }
    }
}
