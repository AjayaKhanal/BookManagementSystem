using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.BookBorrows
{
    public class BookReportsViewModel
    {
        public string BookName { get; set; }
        public int BookBorrowed { get; set; }
        public int Quantity { get; set; }
    }
}
