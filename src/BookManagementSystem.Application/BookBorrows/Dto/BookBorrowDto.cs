using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.Authors;
using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows.Dto
{
    [AutoMapFrom(typeof(BookBorrow))]
    public class BookBorrowDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public string BookName { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string AuthorName { get; set; }

        public int IsReturned { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }

    }
}
