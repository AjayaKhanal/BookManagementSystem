using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Forums
{
    public class ForumManager : DomainService, IForumManager
    {
        private readonly IRepository<Forum> _forumRepository;

        public ForumManager(IRepository<Forum> forumRepository)
        {
            _forumRepository = forumRepository;
        }

        public async Task CreateForumAsync(Forum forum)
        {
            await _forumRepository.InsertAsync(forum);
        }

        public async Task DeleteForumAsync(int id)
        {
            await _forumRepository.DeleteAsync(id);
        }

        public async Task<List<Forum>> GetForumAsync()
        {
            return await _forumRepository.GetAllListAsync();
        }

        public async Task<Forum> GetForumByIdAsync(int id)
        {
            return await _forumRepository.GetAsync(id);
        }

        public async Task UpdateForumAsync(Forum forum)
        {
            await _forumRepository.UpdateAsync(forum);
        }
    }
}
