using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using app2.IServices;
using app2.Models;
using app2.Services;

namespace app2.Controllers
{
    public class BookrecsController : Controller
    {
        private readonly BookRecordService _bookRecordService;

        public BookrecsController()
        {
            _bookRecordService = new BookRecordService();
        }


        // GET: Bookrecs
        public ActionResult Index(string searchstring)
        {
            var search = _bookRecordService.GetBooks();
            if (!String.IsNullOrEmpty(searchstring))
            {
                search = search.Where(s => s.Title.Contains(searchstring));
            }


            return View(search);
        }
        [HttpPost]
        public ActionResult bookdetails(string title)
        {
            var book = _bookRecordService.GetBookByTitle(title);
            ViewBag.bookdetails = book;
            return View("Index", _bookRecordService.GetBooks());

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
                _bookRecordService.SaveBook(bookrec);
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
            Bookrec bookrec = _bookRecordService.GetBookByID(id.Value);
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
                _bookRecordService.UpdateBook(bookrec);
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
            Bookrec bookrec = _bookRecordService.GetBookByID(id.Value);
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
            _bookRecordService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
