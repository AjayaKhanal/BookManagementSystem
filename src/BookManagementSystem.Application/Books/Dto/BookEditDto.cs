using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Books.Dto
{
    public class BookEditDto
    {
        [Required]
        public string BookName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
