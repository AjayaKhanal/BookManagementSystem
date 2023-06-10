using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookAuthors
{
    public interface IBookAuthorManager
    {
        Task<List<BookAuthor>> GetAll();
        Task CreateBookAuthorAsync(BookAuthor bookAuthor);
    }
}
