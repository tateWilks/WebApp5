using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models.ViewModels
{
    public class PagingInfo
    {
        //need to make the page changes a more automatic process - store it dynamically
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage)); //cast to decimal, divide, round up, cast back to int
    }
}
