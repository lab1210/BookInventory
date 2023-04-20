using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using app2.Models;

namespace app2.Controllers
{
    public class BookrecsController : Controller
    {
        private BookrecDBContext db = new BookrecDBContext();

        // GET: Bookrecs
        public ActionResult Index(string searchstring)
        {
            
            var search = from m in db.bookrecs
                         select m;
            if (!String.IsNullOrEmpty(searchstring))
            {
                search = search.Where(s => s.Title.Contains(searchstring));
            }


            return View(search);
        }
        [HttpPost]
        public ActionResult bookdetails(string title)
        {
            var book = db.bookrecs.FirstOrDefault(b => b.Title == title);
            ViewBag.bookdetails = book;
            return View("Index", db.bookrecs.ToList());

        }



        // GET: Bookrecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookrecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Author,ISBN,Creation,PageNo,BarCode,PublishDate,Publisher,UpdateDate")] Bookrec bookrec)
        {
            if (ModelState.IsValid) 
            {
                bookrec.Creation = DateTime.Now;
                bookrec.UpdateDate = DateTime.Now;
                db.bookrecs.Add(bookrec);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookrec);
        }

        // GET: Bookrecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookrec bookrec = db.bookrecs.Find(id);
            if (bookrec == null)
            {
                return HttpNotFound();
            }
            bookrec.UpdateDate=DateTime.Now;
            return View(bookrec);
        }

        // POST: Bookrecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Author,ISBN,Creation,PageNo,BarCode,PublishDate,Publisher,UpdateDate")] Bookrec bookrec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookrec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookrec);
        }

        // GET: Bookrecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookrec bookrec = db.bookrecs.Find(id);
            if (bookrec == null)
            {
                return HttpNotFound();
            }
            return View(bookrec);
        }

        // POST: Bookrecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookrec bookrec = db.bookrecs.Find(id);
            db.bookrecs.Remove(bookrec);
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
