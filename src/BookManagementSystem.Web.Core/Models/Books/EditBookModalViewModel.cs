using BookManagementSystem.Books.Dto;
using BookManagementSystem.BooksAuthors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.Books
{
    public class EditBookModalViewModel
    {
        public BookDto Book { get; set; }

        public BooksAuthorsDto BookAuthor { get; set; }
    }
}
