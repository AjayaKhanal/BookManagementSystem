using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Authors;
using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookAuthors
{
    public class BookAuthor : FullAuditedEntity<int>
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
