using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using JayBugTracker.Models;




namespace JayBugTracker.Controllers
{

    public class AdminController : Controller
    {
      
        private ApplicationDbContext db = new ApplicationDbContext();


        // ========= Index =========== //
        //This is where the user list will be held.

        // ==== G E T =============//
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //var roles = db.Roles.ToList(); 
                    //putting the roles (from the model) in a list
            var users = db.Users.ToList(); 
                    //putting the users (from the model) in a list
            //var model = new UserRoles
            //{
            //    UserList = users,
            //    RoleList = roles,
            //    noRoles = db.Users.Where(j => j.Roles.All(k => k.UserId != j.Id)).ToList()
            //           //linq statement, that puts all users  and roles in one list and then sends it to the model
            //};

            return View(users);
                         //passing the model through the parameter.
                        //why am i not passing my RoleListViewModel inside this parameter?
                
        }

   




        // ========== AddRemoveUsers ========= //


        // ==== G E T =============//
        [Authorize(Roles="Admin")]
        public ActionResult AddRemoveUsers(string id)
        {
            var user = db.Users.Find(id);
            RoleListViewModel rlvm = new RoleListViewModel();
                    //rlvm = role list view model
            UserRoleHelper helper = new UserRoleHelper(); //instance of the class
            var selected = helper.ListUserRoles(id);
            rlvm.RoleName = new MultiSelectList(db.Roles, "Name", "Name", selected);
                    //Db.Roles is getting the roles out of the database and then want the value you want and display in the list is the name. Selected is the variable  that you made so you'll know what variables are already in .
            rlvm.UserId = id;
            rlvm.UserName = user.UserName;
                    //rlvm.UserName = UserName ==> the username of the user
                    // populate the view with the instance of the class // 

            return View(rlvm);
        }

        // ===== P O S T =============//
        [HttpPost]
        public ActionResult AddRemoveUsers(string id, RoleListViewModel model)
        {
                //Passing the viewmodel through the addremoveusers post method because 
                //Call the RoleListViewModel
            UserRoleHelper helper = new UserRoleHelper();
                //Create this instance of the helper because it is not available in the post method until it is created
            if (ModelState.IsValid)
                //making sure the model is valid, everything worked
            {
                string[] empty = { };
                //creating an empty string array
                model.Selected = model.Selected ?? empty;

                foreach (var role in db.Roles)
                {
                    if (model.Selected.Contains(role.Name))
                    {
                        helper.AddUserToRole(id, role.Name);
                    }
                    else
                    {
                        helper.RemoveUserFromRole(id, role.Name);
                    }
                }

                db.SaveChanges();
            }
                return RedirectToAction("Index");
            }
        }
    }


   
    























      