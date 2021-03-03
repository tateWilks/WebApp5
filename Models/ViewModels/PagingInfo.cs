using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models.ViewModels
{
    public class PagingInfo //bundle info to pass to the view
    {
        //need to make the page changes a more automatic process - store it dynamically
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage)); //cast to decimal, divide, round up, cast back to int - use a lambda to make sure that the instance can change - don't want to be stuck with just one value
    }
}
