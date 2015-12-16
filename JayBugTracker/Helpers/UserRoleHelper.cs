using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace JayBugTracker.Models
{
    
    public class UserRoleHelper
    {
        private UserManager<ApplicationUser> manager =
            new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));


        
        public bool IsUserInRole(string userId, string roleName)
        {
            return manager.IsInRole(userId, roleName);
        }     
        
        public IList<string> ListUserRoles(string UserId)
        {
            return manager.GetRoles(UserId);
        }

        
        
        public bool AddUserToRole(string userId, string roleName)
        {
            var result = manager.AddToRole(userId, roleName);
            return result.Succeeded;
        }

        
        
        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var result = manager.RemoveFromRole(userId, roleName);
            return result.Succeeded;
        }

        
        
        public IList<ApplicationUser> UserInRole (string roleName)
        {
            var db = new ApplicationDbContext();
            var resultList = new List<ApplicationUser>();
            
            foreach (var user in db.Users)
            {
                if (IsUserInRole(user.Id, roleName))
                {
                    resultList.Add(user);
                }
            }
            return resultList;
        }

        internal void RemoveUserFromFrole(string p1, string p2)
        {
            throw new NotImplementedException();
        }

   
    }
}