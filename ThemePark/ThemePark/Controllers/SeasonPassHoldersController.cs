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
            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber");
            return View();
        }

        // POST: SeasonPassHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPH_ID,StreetAddress,CityOfAddress,StateOfAddress,ZipCode,FirstName,LastName,MiddleName,TicketNumber")] SeasonPassHolder seasonPassHolder)
        {
            if (ModelState.IsValid)
            {
                db.SeasonPassHolders.Add(seasonPassHolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketNumber = new SelectList(db.Tickets, "TicketNumber", "TicketNumber", seasonPassHolder.TicketNumber);
            return View(seasonPassHolder);
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
