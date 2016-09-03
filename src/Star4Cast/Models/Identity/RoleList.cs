using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Identity
{
    public class RoleList
    {
        public static  RoleList Instance => new RoleList();

        private string[] Roles { get; } = { "Admin" };

        internal string Admin => Roles[0];

        internal IEnumerable<string> All => Roles;
    }
}
