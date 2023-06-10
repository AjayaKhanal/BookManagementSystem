using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Forums
{
    public interface IForumManager
    {
        Task<List<Forum>> GetForumAsync();
        Task<Forum> GetForumByIdAsync(int id);
        Task CreateForumAsync(Forum forum);
        Task UpdateForumAsync(Forum forum);
        Task DeleteForumAsync(int id);
    }
}
