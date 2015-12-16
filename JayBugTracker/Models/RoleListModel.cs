using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



// ==================== RoleList View Model======================================= //
//                                                                                                                                                              //
//                                         Designed specifically for the view                                                                       //
//                                                                                                                                                              //
// ========================================================================//

namespace JayBugTracker.Models
{
    public class RoleListViewModel
    {
        
        
        public MultiSelectList RoleName { get; set; } // Assign multiple roles to 1 user

        public string UserId { get; set; }
        public string UserName { get; set; }

        public string[] Selected { get; set; } // Array
    }
}