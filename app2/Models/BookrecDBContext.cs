using System.Data.Entity;

namespace app2.Models
{
    public class BookrecDBContext:DbContext
    {
        public DbSet<Bookrec> bookrecs { get; set; }
    }
}