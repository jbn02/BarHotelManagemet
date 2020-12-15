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
    public class FoodRateListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //This function is to show food rate list
        // GET: FoodRateLists
        public ActionResult Index()
        {
            var foodRateLists = db.FoodRateLists.Include(f => f.FoodItems);
            return View(foodRateLists.ToList());
        }

        //This function is to show details of food rate list
        // GET: FoodRateLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRateList foodRateList = db.FoodRateLists.Find(id);
            if (foodRateList == null)
            {
                return HttpNotFound();
            }
            return View(foodRateList);
        }

        // GET: FoodRateLists/Create
        public ActionResult Create()
        {
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name");
            return View();
        }

        //This function is to create food rate list
        // POST: FoodRateLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FoodItemID,Rate,PlatType")] FoodRateList foodRateList)
        {
            if (ModelState.IsValid)
            {
                db.FoodRateLists.Add(foodRateList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", foodRateList.FoodItemID);
            return View(foodRateList);
        }


        //This function is to edit food rate list
        // GET: FoodRateLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRateList foodRateList = db.FoodRateLists.Find(id);
            if (foodRateList == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", foodRateList.FoodItemID);
            return View(foodRateList);
        }

        //This function is to update food rate list
        // POST: FoodRateLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FoodItemID,Rate,PlatType")] FoodRateList foodRateList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodRateList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodItemID = new SelectList(db.FoodItems, "ID", "Name", foodRateList.FoodItemID);
            return View(foodRateList);
        }

        // GET: FoodRateLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodRateList foodRateList = db.FoodRateLists.Find(id);
            if (foodRateList == null)
            {
                return HttpNotFound();
            }
            return View(foodRateList);
        }

        //This function is to delete food rate list
        // POST: FoodRateLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodRateList foodRateList = db.FoodRateLists.Find(id);
            db.FoodRateLists.Remove(foodRateList);
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
