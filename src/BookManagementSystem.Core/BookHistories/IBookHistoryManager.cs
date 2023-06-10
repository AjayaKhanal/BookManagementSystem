using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories
{
    public interface IBookHistoryManager
    {
        Task<List<BookHistory>> GetAllAsync();
        Task<BookHistory> GetByIdAsync(int id);
        Task CreateAsync(BookHistory author);
        Task UpdateAsync(BookHistory author);
        Task DeleteAsync(int id);
    }
}
