using System;
using System.Collections.Generic;

#nullable disable

namespace NorthwindCore.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            LnkRolePermissions = new HashSet<LnkRolePermission>();
            LnkUserRoles = new HashSet<LnkUserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsSysAdmin { get; set; }

        public virtual ICollection<LnkRolePermission> LnkRolePermissions { get; set; }
        public virtual ICollection<LnkUserRole> LnkUserRoles { get; set; }
    }
}
