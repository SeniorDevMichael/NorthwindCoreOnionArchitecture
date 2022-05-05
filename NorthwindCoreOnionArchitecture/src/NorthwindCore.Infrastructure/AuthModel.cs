using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindCore.Infrastructure
{
    public class AuthModel
    {
        public string username { get; set; }
        public string password { get; set; }

        public AuthModel()
        {

        }

        public AuthModel(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
