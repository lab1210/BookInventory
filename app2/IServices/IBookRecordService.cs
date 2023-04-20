using app2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app2.IServices
{
    public interface IBookRecordService
    {
       Bookrec GetBookByID(int ID);
       Bookrec GetBookByTitle(string Title);
       IEnumerable<Bookrec> GetBooks();

       void UpdateBook(Bookrec book);
       void DeleteBook(int id);
       Bookrec SaveBook(Bookrec book);
    }
}
