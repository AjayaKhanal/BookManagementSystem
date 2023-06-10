using BookManagementSystem.Authorization.Users;
using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows.Dto
{
    public class BookBorrowListDto
    {
        public string UserName { get; set; }
        public User User { get; set; }

        public string BookName { get; set; }
        public Book Book { get; set; }
    }
}
