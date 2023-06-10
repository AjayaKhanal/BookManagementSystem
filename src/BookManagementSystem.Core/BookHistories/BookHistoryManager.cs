using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories
{
    public class BookHistoryManager: DomainService, IBookHistoryManager
    {
        private readonly IRepository<BookHistory> _bookHistoryRepository;

        public BookHistoryManager(IRepository<BookHistory> bookHistoryRepository)
        {
            _bookHistoryRepository = bookHistoryRepository;
        }

        public async Task<List<BookHistory>> GetAllAsync()
        {
            return await _bookHistoryRepository.GetAllListAsync();
        }

        public async Task<BookHistory> GetByIdAsync(int id)
        {
            return await _bookHistoryRepository.GetAsync(id);
        }

        public async Task CreateAsync(BookHistory author)
        {
            await _bookHistoryRepository.InsertAsync(author);
        }

        public async Task UpdateAsync(BookHistory author)
        {
            await _bookHistoryRepository.UpdateAsync(author);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookHistoryRepository.DeleteAsync(id);
        }
    }
}
