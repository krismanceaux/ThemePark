using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemePark;

namespace ThemePark.Controllers
{
    public class SPHLoginsController : Controller
    {
        private TPContext db = new TPContext();

        // GET: SPHLogins
        public ActionResult Index()
        {
            var sPHLogins = db.SPHLogins.Include(s => s.SeasonPassHolder);
            return View(sPHLogins.ToList());
        }

        // GET: SPHLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPHLogin sPHLogin = db.SPHLogins.Find(id);
            if (sPHLogin == null)
            {
                return HttpNotFound();
            }
            return View(sPHLogin);
        }

        // GET: SPHLogins/Create
        public ActionResult Create()
        {
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress");
            return View();
        }

        // POST: SPHLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginEmail,Pswd,SPH_ID")] SPHLogin sPHLogin)
        {
            if (ModelState.IsValid)
            {
                db.SPHLogins.Add(sPHLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", sPHLogin.SPH_ID);
            return View(sPHLogin);
        }

        // GET: SPHLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPHLogin sPHLogin = db.SPHLogins.Find(id);
            if (sPHLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", sPHLogin.SPH_ID);
            return View(sPHLogin);
        }

        // POST: SPHLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginEmail,Pswd,SPH_ID")] SPHLogin sPHLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPHLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SPH_ID = new SelectList(db.SeasonPassHolders, "SPH_ID", "StreetAddress", sPHLogin.SPH_ID);
            return View(sPHLogin);
        }

        // GET: SPHLogins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPHLogin sPHLogin = db.SPHLogins.Find(id);
            if (sPHLogin == null)
            {
                return HttpNotFound();
            }
            return View(sPHLogin);
        }

        // POST: SPHLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SPHLogin sPHLogin = db.SPHLogins.Find(id);
            db.SPHLogins.Remove(sPHLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
