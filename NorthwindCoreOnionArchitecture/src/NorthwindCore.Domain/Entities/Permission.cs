using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindCore.Domain.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            LnkRolePermissions = new HashSet<LnkRolePermission>();
        }

        public int PermissionId { get; set; }
        public string PermissionDescription { get; set; }

        public virtual ICollection<LnkRolePermission> LnkRolePermissions { get; set; }
    }
}
