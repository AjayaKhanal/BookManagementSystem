using BookManagementSystem.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.Books
{
    public class BookListViewModel
    {
        public IReadOnlyList<BookDto> Book { get; set; }
    }
}
