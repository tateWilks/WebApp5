using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(Book bk, int qty)
        {
            CartLine line = Lines.Where(b => b.Book.BookID == bk.BookID).FirstOrDefault();
            //go out to the Lines where b.Book.BookID (see if it's already there), and then see if that's the same as the bk.BookID, get the first one you find

            if (line == null) //if nothing came of the first search, then we add a new Cartline
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else //if something did come back, then we increase the quantity
            {
                line.Quantity += qty;
            }
        }

        public void RemoveLine(Book bk) => Lines.RemoveAll(b => b.Book.BookID == bk.BookID); //removes all items where the current ID is equal to the Book ID

        public void Clear() => Lines.Clear(); //removes all line items

        public decimal ComputeTotalSum() => Lines.Sum(e => e.Book.Price * e.Quantity); //gives the total price


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
