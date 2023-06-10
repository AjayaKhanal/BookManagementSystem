using BookManagementSystem.Authors.Dto;
using BookManagementSystem.EBookAuthors.Dto;
using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.EBooks
{
    public class EditEBookModalViewModel
    {
        public EBookDto EBook { get; set; }
        public EBookAuthorsDto EBookAuthor { get; set; }
    }
}
