using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2S00092756RAD1.Models;
using System.Net;
using System.Diagnostics;
using System.Data.Entity;


namespace CA2S00092756RAD1.Controllers
{
    public class HomeController : Controller
    {
        private FilmsDB db = new FilmsDB();
        
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.PageTitle = "List of Movies (Total " + db.movies.Count();
            //db.movies.ToList();
            return View(db.movies.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(db.movies.Find(id));
        }

        // GET: Home/Create
        public ActionResult Create(Movies createmov)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db2 = new FilmsDB())
                    {
                        db2.movies.Add(createmov);
                        db2.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.movies.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Movies editmov)
        {
            try
            {
                db.Entry(editmov).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.movies.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.movies.Remove(db.movies.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult DetailsActor(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    var q = db.actors.Find(id); // if no worky, q == null
        //    if (q == null)  // find record?
        //    {
        //        Debug.WriteLine("No Actors Found");
        //        ViewBag.PageTitle = String.Format("Sorry, Actor record {0} not found.", id);
        //        //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //    }
        //    else ViewBag.PageTitle = "Actors in movie " + q.ScreenName + " (" + ((q.ScreenName.Count == 0) ? "None" : q.ScreenName.Count.ToString()) + ')';
        //    return View(q.actorMovie);
        //}

    }
}
