using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions
{
    public interface ISuggestionManager
    {
        Task<List<Suggestion>> GetSuggestionAsync();
        Task<Suggestion> GetSuggestionByIdAsync(int id);
        Task CreateSuggestionAsync(Suggestion suggestion);
    }
}
