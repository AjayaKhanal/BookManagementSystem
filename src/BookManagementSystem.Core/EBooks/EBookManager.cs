using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks
{
    public class EBookManager : DomainService, IEBookManager
    {
        private readonly IRepository<EBook> _eBookRepository;

        public EBookManager(IRepository<EBook> eBookRepository)
        {
            _eBookRepository = eBookRepository;
        }

        public async Task<List<EBook>> GetEBooksAsync()
        {
            return await _eBookRepository.GetAllListAsync();
        }

        public async Task<EBook> GetEBooksByIdAsync(int id)
        {
            return await _eBookRepository.GetAsync(id);
        }

        public async Task CreateEBookAsync(EBook eBook)
        {
            await _eBookRepository.InsertAsync(eBook);
        }

        public async Task UpdateEBookAsync(EBook eBook)
        {
            await _eBookRepository.UpdateAsync(eBook);
        }

        public async Task DeleteEBookAsync(int id)
        {
            await _eBookRepository.DeleteAsync(id);
        }
    }
}
