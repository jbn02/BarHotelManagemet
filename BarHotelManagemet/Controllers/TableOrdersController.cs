using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarHotelManagemet.Models;

namespace BarHotelManagemet.Controllers
{
    public class TableOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This function is to show table order list
        // GET: TableOrders
        public ActionResult Index()
        {
            return View(db.TableOrders.ToList());
        }

        //This function is to show detail of table order
        // GET: TableOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOrder tableOrder = db.TableOrders.Find(id);
            if (tableOrder == null)
            {
                return HttpNotFound();
            }
            return View(tableOrder);
        }

        // GET: TableOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        //This function is to add table order
        // POST: TableOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,OrderNo,KOT,OrderDate")] TableOrder tableOrder)
        {
            if (ModelState.IsValid)
            {
                db.TableOrders.Add(tableOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableOrder);
        }

        // GET: TableOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOrder tableOrder = db.TableOrders.Find(id);
            if (tableOrder == null)
            {
                return HttpNotFound();
            }
            return View(tableOrder);
        }

        //This function is to update table order
        // POST: TableOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,OrderNo,KOT,OrderDate")] TableOrder tableOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableOrder);
        }

        // GET: TableOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableOrder tableOrder = db.TableOrders.Find(id);
            if (tableOrder == null)
            {
                return HttpNotFound();
            }
            return View(tableOrder);
        }

        //This function is to delete table orders
        // POST: TableOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableOrder tableOrder = db.TableOrders.Find(id);
            db.TableOrders.Remove(tableOrder);
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
