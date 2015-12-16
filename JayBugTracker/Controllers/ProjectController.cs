using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using JayBugTracker.Models;
using System.Net;
using System.Data.Entity;


namespace JayBugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // pulling the database from identity model so all classes can see it



        //============= I N D E X ============================================/




        public ActionResult Index()
        {
            var projects = db.Projects.ToList();

            return View(projects);
        }



        //================================================================//



        //============= C R E A T E ============================================//


        //==== G E T==== //

        public ActionResult Create()
        {
            return View();
        }


        //==== P O S T=== //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Created,Updated")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.Created = System.DateTimeOffset.Now;
            }
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //================================================================//




        //============= E D I T  ============================================/


        //==== G E T==== //


        public ActionResult Edit(int? id)
        {
            // passing the project through the actionresult by its id to ensure the correct project is being edited
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // if id is null, then return a bad request notification
            Project project = db.Projects.Find(id);
            // finding the project by its unique identifier in the database
            if (project == null)
            {
                // if project is null then return HttpNotFound
                return HttpNotFound();
            }
            return View(project);
            // otherwise return the project.
        }


        //==== P O S T==== //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Created,Updated")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.Updated = System.DateTimeOffset.Now;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //================================================================//



        //============= D E L E T E  ============================================/


        //==== G E T==== //

        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

            //==== P O S T==== //


           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]
           public ActionResult DeleteConfirmed(int id)
           {
               Project project = db.Projects.Find(id);
               db.Projects.Remove(project);
               db.SaveChanges();
               return RedirectToAction("Index");
           }

        //================================================================//



        //============= D E T A I L S ============================================//

        //==== G E T==== //

        public ActionResult Details (int id)
           {
               Project project = db.Projects.Find(id);
           
            return View(project);
        }


      

        
    }
}