using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows
{
    public interface IBookBorrowManager
    {
        Task<List<BookBorrow>> GetBookBorrowAsync();
        Task<BookBorrow> GetBookBorrowByIdAsync(int id);
        Task CreateBookBorrowAsync(BookBorrow bookBorrow);
        Task UpdateBookBorrowAsync(BookBorrow bookBorrow);
    }
}
