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
        public IQueryable<Book> Books => _context.Books; //lambda does something where the variable constantly updates - GOOGLE THIS - it makes an anonymous function - don't want a static instance

    }
}
