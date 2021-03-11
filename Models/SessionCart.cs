using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace WebApp5.Models
{
    public class SessionCart : Cart //sub class, inherits from cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart(); //make sure all the names match up correctly
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        //all of these methods will override the original methods
        public override void AddItem(Book bk, int quantity)
        {
            base.AddItem(bk, quantity); //use the Cart method, not the subclass method
            Session.SetJson("cart", this); //then set the session
        }

        public override void RemoveLine(Book product)
        {
            base.RemoveLine(product);
            Session.SetJson("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("cart");
        }
    }
}
