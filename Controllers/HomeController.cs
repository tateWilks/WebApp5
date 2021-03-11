﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Models;
using WebApp5.Models.ViewModels;

namespace WebApp5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _repository;
        public int PageSize = 5; //create a public items page variable

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository; //going to get the book repository and set it equal to the _repository variable
        }

        //new dynamic Index controller
        public IActionResult Index(string category, int pageNum = 1)
        {
            return View(new BookListViewModel //BookListViewModel has two attributes : IEnumerable<Books> and PagingInfo -> we create that here with Books = _repository.Books and PagingInfo = new PagingInfo{ passing values to a constructor }
                { 
                    Books = _repository.Books
                        .Where(c => category == null || c.Category == category) //this statement says that we want to filter the data where the category is null or where the category is the category passed in
                        .OrderBy(b => b.BookID)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ?
                            _repository.Books.Count() : //if the category is null, grab everything for total items. 
                            _repository.Books.Where(b => b.Category == category).Count() //otherwise, only get the item count for books that have a category equal to the category passed in
                    },
                    CurrentCategory = category
            });;
        }

        //this was what we did earlier, now we order them as above
        /*public IActionResult Index(int page = 1) //pass it to the index view -> ?page=2 in the URL can navigate for us
        {
            return View(
                _repository.Books
                .OrderBy(b => b.BookID) //lambda that says the pages will be ordered by the BookID
                .Skip((page - 1) * ItemsPerPage) //this takes us to element 2 in our array of projects -> 0 and 1 will be on the first page, after that we can take
                .Take(ItemsPerPage) //takes the next number to display - this is the query that we write out written in Linq - we can also use raw SQL
                ); //return the view with the book repo
        } */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
