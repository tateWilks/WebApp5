using Microsoft.AspNetCore.Mvc;
using WebApp5.Models;

namespace WebApp5.Components
{
    public class CartSummaryViewComponent : ViewComponent //create another component to view just the little bit of html we wanna generate for the cart info
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
