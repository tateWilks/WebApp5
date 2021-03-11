using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp5.Infrastructure;
using WebApp5.Models;

namespace WebApp5.Pages
{
    public class CheckoutModel : PageModel
    {
        private IBookRepository repository;

        //constructor
        public CheckoutModel(IBookRepository repo)
        {
            repository = repo;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //if it doesn't have a return url, then just have it go to home
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); //get a new cart if nothing is out there
        }

        public IActionResult OnPost(long bookId, string returnUrl) //the long here (id) NEEDS to match the asp-for on the html end of things (not case sensitive) --> in general, just keep things the same name as much as you can
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId); //look at the repo to see if there is something there

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); //get the cart or add a new cart

            Cart.AddItem(book, 1); //add the new item

            HttpContext.Session.SetJson("cart", Cart); //set the new cart

            return RedirectToPage(new { returnUrl = returnUrl }); //return to the page that you were on
        }
    }
}
