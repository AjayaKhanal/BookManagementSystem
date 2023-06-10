using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks
{
    public interface IEBookManager
    {
        Task<List<EBook>> GetEBooksAsync();
        Task<EBook> GetEBooksByIdAsync(int id);
        Task CreateEBookAsync(EBook eBook);
        Task UpdateEBookAsync(EBook eBook);
        Task DeleteEBookAsync(int id);
    }
}