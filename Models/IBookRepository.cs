using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models
{
    //interface template NOT A CLASS - meant to be inherited to help us control what's in the class
    public interface IBookRepository //meant to be inherited
    {
        IQueryable<Book> Books { get; } //only allowed to get - query - the stuff

        //IQueryable - getting data from outside databases (good for LINQ to SQL)
        //IEnumerable - getting data out of in-memory things (like lists and arrays - good for LINQ to XML)
    }
}
