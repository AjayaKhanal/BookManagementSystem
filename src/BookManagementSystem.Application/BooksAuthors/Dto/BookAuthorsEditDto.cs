using BookManagementSystem.Authors.Dto;
using BookManagementSystem.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BooksAuthors.Dto
{
    public class BookAuthorsEditDto
    {
        public int BookId { get; set; }
        public BookDto Book { get; set; }

        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
