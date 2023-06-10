using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.Authors;
using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows
{
    public class BookBorrow : FullAuditedEntity<int>
    {
        public long UserId{ get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int IsReturned { get; set; }
    }
}
