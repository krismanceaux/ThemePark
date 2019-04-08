using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemePark;
using ThemePark.DAL;
using ThemePark.ViewModels;

namespace ThemePark.Controllers
{
    public class SeasonPassHoldersController : Controller
    {
        private TPContext db = new TPContext();

        // GET: SeasonPassHolders
        public ActionResult Index()
        {
            var seasonPassHolders = db.SeasonPassHolders.Include(s => s.Ticket);
            return View(seasonPassHolders.ToList());
        }

        // GET: SeasonPassHolders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonPassHolder seasonPassHolder = db.SeasonPassHolders.Find(id);
            if (seasonPassHolder == null)
            {
                return HttpNotFound();
            }
            return View(seasonPassHolder);
        }

        // GET: SeasonPassHolders/Create
        public ActionResult Create()
        {
            ViewBag.TicketNumber = ApplicationSession.TicketNumber;
            SPH_VM sph = new SPH_VM();
            sph.TicketNumber = ApplicationSession.TicketNumber;
            return View(sph);
        }

        // POST: SeasonPassHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SPH_VM sph)
        {
            if (ModelState.IsValid)
            {
                SeasonPassHolder seasonPassHolder = new SeasonPassHolder();
                seasonPassHolder.FirstName = sph.FirstName;
                seasonPassHolder.MiddleName = sph.MiddleName;
                seasonPassHolder.LastName = sph.LastName;
                seasonPassHolder.StreetAddress = sph.StreetAddress;
                seasonPassHolder.CityOfAddress = sph.CityOfAddress;
                seasonPassHolder.StateOfAddress = sph.StateOfAddress;
                seasonPassHolder.ZipCode = sph.ZipCode;
                seasonPassHolder.TicketNumber = ApplicationSession.TicketNumber;

                SPHLogin login = new SPHLogin();
                login.LoginEmail = sph.LoginEmail;
                login.Pswd = sph.Pswd;
                login.SeasonPassHolder = seasonPassHolder;

                ApplicationSession.Username = sph.LoginEmail;
                ApplicationSession.AccessLevel = "SPH";

                db.SeasonPassHolders.Add(seasonPassHolder);
                db.SPHLogins.Add(login);
                db.SaveChanges();
                return RedirectToAction("DepQuestion", "DependentPassHolders");
            }

            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", sph.TicketNumber);
            return View(sph);
        }

        // GET: SeasonPassHolders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonPassHolder seasonPassHolder = db.SeasonPassHolders.Find(id);
            if (seasonPassHolder == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", seasonPassHolder.TicketNumber);
            return View(seasonPassHolder);
        }

        // POST: SeasonPassHolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPH_ID,StreetAddress,CityOfAddress,StateOfAddress,ZipCode,FirstName,LastName,MiddleName,TicketNumber")] SeasonPassHolder seasonPassHolder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seasonPassHolder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", seasonPassHolder.TicketNumber);
            return View(seasonPassHolder);
        }

        // GET: SeasonPassHolders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeasonPassHolder seasonPassHolder = db.SeasonPassHolders.Find(id);
            if (seasonPassHolder == null)
            {
                return HttpNotFound();
            }
            return View(seasonPassHolder);
        }

        // POST: SeasonPassHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            SeasonPassHolder seasonPassHolder = db.SeasonPassHolders.Find(id);
            db.SeasonPassHolders.Remove(seasonPassHolder);
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
