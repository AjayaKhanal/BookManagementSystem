using BookManagementSystem.Authors.Dto;
using BookManagementSystem.EBookAuthors.Dto;
using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.EBooks
{
    public class EBookDetailsViewModel
    {
        public EBookDto EBook { get; set; }
        public AuthorDto Author { get; set; }
        public EBookAuthorsDto EBookAuthor { get; set; }
    }
}
