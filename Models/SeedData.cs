using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            DatabaseContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();

            if (context.Database.GetPendingMigrations().Any()) //needed to specify the data path with " AttachDbFilename=|DataDirectory|twilksWebApp5DB.mdf " in the Connection Strings section of the .json file
            {
                context.Database.Migrate(); //this saves it in C:\Users\tatew\source\repos\WebApp5\bin\Debug\netcoreapp3.1
            }

            if (!context.Books.Any())
            {
                //we seed the data here and then we go from there 
                context.Books.AddRange(
                    new Book
                    {                        
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95M,
                        NumPages = 1488
                    },

                    new Book
                    {                        
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58M,
                        NumPages = 944
                    },

                    new Book
                    {                       
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54M,
                        NumPages = 832
                    },

                    new Book
                    {                        
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61M,
                        NumPages = 864
                    },

                    new Book
                    {                        
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33M,
                        NumPages = 528
                    },

                    new Book
                    {                        
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95M,
                        NumPages = 288
                    },

                    new Book
                    {                        
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99M,
                        NumPages = 304
                    },

                    new Book
                    {                        
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66M,
                        NumPages = 240
                    },

                    new Book
                    {                        
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16M,
                        NumPages = 400
                    },

                    new Book
                    {                        
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03M,
                        NumPages = 642
                    },
                    new Book //my three books
                    {
                        Title = "Ender's Game",
                        AuthorFirst = "Orson",
                        AuthorMiddle = "Scott",
                        AuthorLast = "Card",
                        Publisher = "Tor Science Fiction",
                        ISBN = "978-0812550702",
                        Classification = "Fiction",
                        Category = "Science Fiction",
                        Price = 7.99M,
                        NumPages = 352
                    },
                    new Book
                    {
                        Title = "1984",
                        AuthorFirst = "George",
                        AuthorLast = "Orwell",
                        Publisher = "Berkley",
                        ISBN = "978-0452284234",
                        Classification = "Fiction",
                        Category = "Fiction",
                        Price = 14.99M,
                        NumPages = 368
                    },
                    new Book
                    {
                        Title = "The Things They Carried",
                        AuthorFirst = "Tim",
                        AuthorLast = "O'Brien",
                        Publisher = "Mariner Books",
                        ISBN = "978-0544309760",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 11.21M,
                        NumPages = 233
                    }
                );
                //save the changes into the repository
                context.SaveChanges();
            }
        }
    }
}
