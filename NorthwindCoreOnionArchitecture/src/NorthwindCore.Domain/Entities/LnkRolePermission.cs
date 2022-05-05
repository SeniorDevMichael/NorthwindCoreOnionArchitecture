using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindCore.Domain.Entities
{
    public partial class LnkRolePermission
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
