using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies
{
    public interface IForumReplyManager
    {
        Task<ForumReply> GetForumReplyByIdAsync(int id);
        Task<List<ForumReply>> GetForumReplyAsync();
        Task CreateForumReplyAsync(ForumReply forumReply);
        Task DeleteForumReplyAsync(int id);
        Task UpdateForumReplyAsync(ForumReply forumReply);
    }
}
