using BookManagementSystem.Authors.Dto;
using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookAuthors.Dto
{
    public class CreateEBookAuthorDto
    {
        public int EBookId { get; set; }
        public EBookDto EBook { get; set; }

        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
    }
}
