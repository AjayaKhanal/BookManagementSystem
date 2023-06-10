using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Authors;
using BookManagementSystem.EBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookAuthors
{
    public class EBookAuthor : FullAuditedEntity<int>
    {
        public int EBookId { get; set; }
        public EBook EBook { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
