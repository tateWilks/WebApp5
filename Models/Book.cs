using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp5.Models
{
    public class Book
    {
        //set all the attributes for the book class - normalized and atomic
        [Key] //set the key
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; } //break the author name into first and last, but we will display it all as one string in the view
        public string AuthorMiddle { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}\-[0-9]{10}$", ErrorMessage ="Please enter a valid ISBN")] //set the regex for the ISBN
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; } //break classification and category into atomic groups
        [Required]
        public string Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")] //specify the decimal field 
        public decimal Price { get; set; }
    }
}
