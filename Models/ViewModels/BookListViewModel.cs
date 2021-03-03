using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//this is a model that is built specifically as a "bundle" for a view

namespace WebApp5.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; } // IEnumerable ensures immutability - we don't want that stuff to change - also increases efficiency - An IEnumerable is built to facilitate in the process of iterating a group of objects.
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
