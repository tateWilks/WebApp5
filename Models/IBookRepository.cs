using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models
{
    public interface IBookRepository //meant to be inherited
    {
        IQueryable<Book> Books { get; } //only allowed to get - query - the stuff
    }
}
