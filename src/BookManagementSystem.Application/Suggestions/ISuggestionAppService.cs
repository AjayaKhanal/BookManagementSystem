using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.Suggestions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions
{
    public interface ISuggestionAppService : IAsyncCrudAppService<SuggestionDto, int, PagedSuggestionResultRequestDto, AddSuggestionDto, SuggestionDto>
    {
        Task<SuggestionDto> AddSuggestionAsync(AddSuggestionDto input);
        Task<ListResultDto<SuggestionDto>> GetSuggestionsAsync();
    }
}
