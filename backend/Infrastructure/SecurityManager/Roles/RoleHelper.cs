using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SecurityManager.Roles
{
    public class RoleHelper
    {
        public static List<string> GetAdminRoles()
        {
            var roles = new List<string>();
            // roles = NavigationTreeStructure.GetCompleteFirstMenuNavigationSegment();
            return roles;
        }

        //make sure or cross check with NavigationTreeStructure
        public static string GetProfileRole()
        {
            return "Profiles";
        }
    }
}
