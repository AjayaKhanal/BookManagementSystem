using BookManagementSystem.Authorization.Users;
using BookManagementSystem.BookAuthors;
using BookManagementSystem.BookHistories.Dto;
using BookManagementSystem.EBookAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.BookHistory
{
    public class BookHistoryViewModel
    {
        public IReadOnlyList<BookHistoryDto> BookHistory { get; set; }
    }
}
