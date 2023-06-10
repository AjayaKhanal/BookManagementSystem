using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies
{
    public class ForumReplyManager : DomainService, IForumReplyManager
    {
        private readonly IRepository<ForumReply> _forumReplyRepository;

        public ForumReplyManager(IRepository<ForumReply> forumReplyRepository)
        {
            _forumReplyRepository = forumReplyRepository;
        }

        public async Task CreateForumReplyAsync(ForumReply forumReply)
        {
            await _forumReplyRepository.InsertAsync(forumReply);
        }

        public async Task DeleteForumReplyAsync(int id)
        {
            await _forumReplyRepository.DeleteAsync(id);
        }

        public async Task<List<ForumReply>> GetForumReplyAsync()
        {
            return await _forumReplyRepository.GetAllListAsync();
        }

        public async Task<ForumReply> GetForumReplyByIdAsync(int id)
        {
            return await _forumReplyRepository.GetAsync(id);
        }

        public async Task UpdateForumReplyAsync(ForumReply forumReply)
        {
            await _forumReplyRepository.UpdateAsync(forumReply);
        }
    }
}
