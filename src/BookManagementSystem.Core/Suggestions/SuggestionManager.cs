using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions
{
    public class SuggestionManager : DomainService, ISuggestionManager
    {
        private readonly IRepository<Suggestion> _suggestionRepository;

        public SuggestionManager(IRepository<Suggestion> suggestionRepository)
        {
            _suggestionRepository = suggestionRepository;
        }

        public async Task CreateSuggestionAsync(Suggestion suggestion)
        {
            await _suggestionRepository.InsertAsync(suggestion);
        }

        public async Task<List<Suggestion>> GetSuggestionAsync()
        {
            return await _suggestionRepository.GetAllListAsync();
        }

        public async Task<Suggestion> GetSuggestionByIdAsync(int id)
        {
            return await _suggestionRepository.GetAsync(id);
        }
    }
}
