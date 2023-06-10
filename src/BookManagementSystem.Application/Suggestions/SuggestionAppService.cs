using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Suggestions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions
{
    public class SuggestionAppService : AsyncCrudAppService<Suggestion, SuggestionDto, int, PagedSuggestionResultRequestDto, AddSuggestionDto, SuggestionDto>, ISuggestionAppService
    {
        private readonly ISuggestionManager _suggestionManager;

        public SuggestionAppService(
            IRepository<Suggestion, int> repository,
            ISuggestionManager suggestionManager
            ) : base(repository)
        {
            _suggestionManager = suggestionManager;
        }

        public async Task<SuggestionDto> AddSuggestionAsync(AddSuggestionDto input)
        {
            CheckCreatePermission();

            var suggestion = new Suggestion { SuggestionDescription = input.SuggestionDescription };
            suggestion.CreationTime = Clock.Now;
            suggestion.CreatorUserId = AbpSession.GetUserId();

            await _suggestionManager.CreateSuggestionAsync(suggestion);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new SuggestionDto() { SuggestionDescription = suggestion.SuggestionDescription, CreationTime = suggestion.CreationTime, CreatedBy = suggestion.CreatorUserId.ToString() };
        }

        public async Task<ListResultDto<SuggestionDto>> GetSuggestionsAsync()
        {
            var suggestions = await _suggestionManager.GetSuggestionAsync();
            return new ListResultDto<SuggestionDto>(ObjectMapper.Map<List<SuggestionDto>>(suggestions));
        }

    }
}
