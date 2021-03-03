using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Models;

namespace WebApp5.Components //a component is reusable application logic that we want to use multiple times in the program
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository _repository;
        public NavigationMenuViewComponent (IBookRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"]; //has a global scope so we can access this anywhere. we are going to give it a value and write route data into it

            return View(_repository.Books
                .Select(c => c.Category) //select all categories (distinct) and order them
                .Distinct()
                .OrderBy(c => c)
            );
        }
    }
}
