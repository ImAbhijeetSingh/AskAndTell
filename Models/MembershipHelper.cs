using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskAndTell.Models
{
    public class MembershipHelper
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));
        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));

        //AddRole
        public static void AddRole(string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole { Name = roleName });
            }
        }
        //RemoveRole

        // CheckIfUserIsInRole
        public static bool CheckIfUserIsInRole(string userId, string role)
        {
            var result = userManager.IsInRole(userId, role);
            return result;
        }

        //AddUserToRole
        public static bool AddUserToRole(string userId, string role)
        {
            if (CheckIfUserIsInRole(userId, role))
                return false;
            else
            {
                userManager.AddToRole(userId, role);
                return true;
            }
        }
    }
}