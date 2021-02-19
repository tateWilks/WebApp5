using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models
{
    public class EFBookRepository : IBookRepository
    {
        private DatabaseContext _context;
        //constructor
        public EFBookRepository(DatabaseContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books; //lambda makes the Books equal to the DbSet (?)

    }
}
