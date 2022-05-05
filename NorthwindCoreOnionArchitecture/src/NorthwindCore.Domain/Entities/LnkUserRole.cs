using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindCore.Domain.Entities
{
    public partial class LnkUserRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
