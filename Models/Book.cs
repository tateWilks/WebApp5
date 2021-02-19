using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp5.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}\-[0-9]{10}$", ErrorMessage ="Please enter a valid ISBN")]
        public string ISBN { get; set; }
        [Required]
        public string ClassificationCategory { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
