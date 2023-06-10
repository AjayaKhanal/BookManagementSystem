using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using BookManagementSystem.Authorization.Roles;
using BookManagementSystem.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors
{
    public class AuthorManager : DomainService, IAuthorManager
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorManager(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAuthorAsync()
        {
            return await _authorRepository.GetAllListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAsync(id);
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _authorRepository.InsertAsync(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorRepository.UpdateAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _authorRepository.DeleteAsync(id);
        }
        
    }
}
