using BookManagementSystem.Authorization.Users;
using BookManagementSystem.EBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories.Dto
{
    public class BookHistoryListDto
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public int EBookId { get; set; }
        public EBook EBook { get; set; }
    }
}
