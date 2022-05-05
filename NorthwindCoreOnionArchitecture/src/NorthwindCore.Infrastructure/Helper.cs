using Microsoft.AspNetCore.Http;
using NorthwindCore.Domain.Entities;
using NorthwindCore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCore.Infrastructure
{
    public class Helper
    {
        public static bool CheckUser(string username, string password)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                return db.Users.Any(x=>x.Username==username && x.Password==password);
            }
        }

        public static bool CheckUserPermissionForApi(AuthModel authModel, string permissionName)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var permission = db.Permissions.FirstOrDefault(x => x.PermissionDescription == "Categories-GetAllCategories");
                var rlprm = db.LnkRolePermissions.Where(x => x.PermissionId == permission.PermissionId);

                var rl_user = db.LnkUserRoles.Where(x => x.UserId == 1);

                var usr = db.Users.Where(x => x.Username == authModel.username && x.Password == authModel.password);



                var user = db.Users.FirstOrDefault(x => x.Username == authModel.username && x.Password == authModel.password);
                
                var curr_roleId = db.LnkUserRoles.FirstOrDefault(x => x.UserId == user.UserId).RoleId;
                var curr_permission = db.Permissions.FirstOrDefault(x => x.PermissionDescription == permissionName);
                
                return db.LnkRolePermissions.Any(x => x.PermissionId == curr_permission.PermissionId && x.RoleId == curr_roleId);
            }
        }

        public static AuthModel GetUserInfoFromAuth(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            string ecodeUsernameAndPassword = authHeader.Substring("Basic ".Length).Trim();

            Encoding encoding = Encoding.GetEncoding("UTF-8");

            string usernameAndPassword = encoding.GetString(Convert.FromBase64String(ecodeUsernameAndPassword));

            int index = usernameAndPassword.IndexOf(":");

            var _username = usernameAndPassword.Substring(0, index);
            var _password = usernameAndPassword.Substring(index + 1);

            return new AuthModel() { username = _username, password = _password};
        }
    }
}
