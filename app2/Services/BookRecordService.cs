using app2.IServices;
using app2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace app2.Services
{
    public class BookRecordService: IBookRecordService
    {

        private BookrecDBContext _db;
        public BookRecordService()
        {
            this._db = new BookrecDBContext();
        }
        public Bookrec GetBookByID(int ID)
        {
            return this._db.bookrecs.Find(ID);
        }
        public Bookrec GetBookByTitle(string Title)
        {
            return this._db.bookrecs.FirstOrDefault(x => x.Title == Title);
        }
        public IEnumerable<Bookrec> GetBooks()
        {
            var result = from m in this._db.bookrecs
                   select m;
            return result;

        }
        public void UpdateBook(Bookrec book)
        {
            this._db.Entry(book).State = EntityState.Modified;
            this._db.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = GetBookByID(id);
            this._db.bookrecs.Remove(book);
            this._db.SaveChanges();
        }
        public Bookrec SaveBook(Bookrec book)
        {

            book.Creation = DateTime.Now;
            book.UpdateDate = DateTime.Now;
            this._db.bookrecs.Add(book);

            this._db.SaveChanges();
            return book;
        }
    }
}