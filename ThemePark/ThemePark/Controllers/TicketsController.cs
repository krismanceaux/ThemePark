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
    public class TicketsController : Controller
    {
        private TPContext db = new TPContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.TicketCode1);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.TicketCode = new SelectList(db.TicketCodes, "TicketCode1", "TicketType");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketNumber,Price,DateOfPurchase,TicketCode")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                if (ticket.TicketCode == 1) ticket.Price = (decimal)12.00;
                else if (ticket.TicketCode == 2) ticket.Price = (decimal)8.00;
                else if (ticket.TicketCode == 3) ticket.Price = (decimal)10.00;
                else if (ticket.TicketCode == 4) ticket.Price = (decimal)10.00;
                else if (ticket.TicketCode == 5) ticket.Price = (decimal)40.00;
                ticket.DateOfPurchase = DateTime.Now.Date;
                db.Tickets.Add(ticket);
                db.SaveChanges();

                
                if (ticket.TicketCode == 5)
                {
                    ApplicationSession.TicketNumber = ticket.TicketNumber;
                    return RedirectToAction("Create", "SeasonPassholders");
                }
                else
                    return RedirectToAction("Receipt", "Tickets");
            }

            ViewBag.TicketCode = new SelectList(db.TicketCodes, "TicketCode1", "TicketType", ticket.TicketCode);
            return View(ticket);
        }

        


        // GET: Tickets/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketCode = new SelectList(db.TicketCodes, "TicketCode1", "TicketType", ticket.TicketCode);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketNumber,Price,DateOfPurchase,TicketCode")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketCode = new SelectList(db.TicketCodes, "TicketCode1", "TicketType", ticket.TicketCode);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Receipt()
        {

            var receipt = db.Tickets.OrderByDescending(t => t.TicketNumber).FirstOrDefault();
            
            return View(receipt);
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
