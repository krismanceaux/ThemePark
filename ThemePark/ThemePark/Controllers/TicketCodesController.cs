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
    public class TicketCodesController : Controller
    {
        private TPContext db = new TPContext();

        // GET: TicketCodes
        public ActionResult Index()
        {
            return View(db.TicketCodes.ToList());
        }

        // GET: TicketCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCode ticketCode = db.TicketCodes.Find(id);
            if (ticketCode == null)
            {
                return HttpNotFound();
            }
            return View(ticketCode);
        }

        // GET: TicketCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketCode1,TicketType")] TicketCode ticketCode)
        {
            if (ModelState.IsValid)
            {
                db.TicketCodes.Add(ticketCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketCode);
        }

        // GET: TicketCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCode ticketCode = db.TicketCodes.Find(id);
            if (ticketCode == null)
            {
                return HttpNotFound();
            }
            return View(ticketCode);
        }

        // POST: TicketCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketCode1,TicketType")] TicketCode ticketCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketCode);
        }

        // GET: TicketCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCode ticketCode = db.TicketCodes.Find(id);
            if (ticketCode == null)
            {
                return HttpNotFound();
            }
            return View(ticketCode);
        }

        // POST: TicketCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketCode ticketCode = db.TicketCodes.Find(id);
            db.TicketCodes.Remove(ticketCode);
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
