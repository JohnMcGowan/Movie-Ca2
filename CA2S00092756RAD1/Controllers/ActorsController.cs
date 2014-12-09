using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2S00092756RAD1.Models;
using System.Data.Entity;

namespace CA2S00092756RAD1.Controllers
{
    public class ActorsController : Controller
    {
        private FilmsDB db = new FilmsDB();
        // GET: Actors
        public ActionResult Index()
        {
            ViewBag.PageTitle = "List of Movies (Total " + db.movies.Count();
            return View(db.actors.ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int id)
        {
            return View(db.actors.Find(id));
        }

        // GET: Actors/Create
        public ActionResult Create(Actors createatr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db2 = new FilmsDB())
                    {
                        db2.actors.Add(createatr);
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
         
        public ActionResult Edit(int id)
        {
            return View(db.actors.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Actors editact)
        {
            try
            {

                db.Entry(editact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(db.actors.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.actors.Remove(db.actors.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
