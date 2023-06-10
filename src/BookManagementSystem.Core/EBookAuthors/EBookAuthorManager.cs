using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookAuthors
{
    public class EBookAuthorManager : DomainService, IEBookAuthorManager
    {
        private readonly IRepository<EBookAuthor> _eBookAuthorRepository;

        public EBookAuthorManager(IRepository<EBookAuthor> eBookAuthorRepository)
        {
            _eBookAuthorRepository = eBookAuthorRepository;
        }

        public async Task<List<EBookAuthor>> GetEBookAuthorsAsync()
        {
            return await _eBookAuthorRepository.GetAllListAsync();
        }

        public async Task<EBookAuthor> GetEBookAuthorsByIdAsync(int id)
        {
            return await _eBookAuthorRepository.GetAsync(id);
        }

        public async Task CreateEBookAuthorsAsync(EBookAuthor eBookAuthor)
        {
            await _eBookAuthorRepository.InsertAsync(eBookAuthor);
        }

        public async Task UpdateEBookAuthorsAsync(EBookAuthor eBookAuthor)
        {
            await _eBookAuthorRepository.UpdateAsync(eBookAuthor);
        }

        public async Task DeleteEBookAuthorsAsync(int id)
        {
            await _eBookAuthorRepository.DeleteAsync(id);
        }
    }
}
