using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab8910;

namespace Lab8910.Controllers
{
    public class OrderssesController : Controller
    {
        private DevConn db = new DevConn();

        // GET: Ordersses
        public ActionResult Index()
        {
            var ordersses = db.Ordersses.Include(o => o.Agent);
            return View(ordersses.ToList());
        }

        // GET: Ordersses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderss orderss = db.Ordersses.Find(id);
            if (orderss == null)
            {
                return HttpNotFound();
            }
            return View(orderss);
        }

        // GET: Ordersses/Create
        public ActionResult Create()
        {
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "AgentName");
            return View();
        }

        // POST: Ordersses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDate,AgentID")] Orderss orderss)
        {
            if (ModelState.IsValid)
            {
                db.Ordersses.Add(orderss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "AgentName", orderss.AgentID);
            return View(orderss);
        }

        // GET: Ordersses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderss orderss = db.Ordersses.Find(id);
            if (orderss == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "AgentName", orderss.AgentID);
            return View(orderss);
        }

        // POST: Ordersses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,AgentID")] Orderss orderss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentID = new SelectList(db.Agents, "AgentID", "AgentName", orderss.AgentID);
            return View(orderss);
        }

        // GET: Ordersses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orderss orderss = db.Ordersses.Find(id);
            if (orderss == null)
            {
                return HttpNotFound();
            }
            return View(orderss);
        }

        // POST: Ordersses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Orderss orderss = db.Ordersses.Find(id);
            db.Ordersses.Remove(orderss);
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
