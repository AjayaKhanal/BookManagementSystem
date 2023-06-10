using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.EBookAuthors;
using BookManagementSystem.EBookAuthors.Dto;
using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks
{
    public interface IEBookAppService : IAsyncCrudAppService<EBookDto, int, PagedEBookResultRequestDto, CreateEBookDto, EBookDto>
    {
        Task<EBookDto> CreateAsync(CreateEBookDto input);
        Task<EBookAuthorsDto> CreateEBookAndAuthorsAsync(CreateEBookAuthorDto input);
        Task<EBookDto> UpdateAsync(EBookDto input);
        Task<EBookAuthorsDto> UpdateEBookAuthorsAsync(EBookAuthor input);
        Task<ListResultDto<EBookDto>> GetEBooksAsync();
        Task DeleteAsync(EntityDto<int> input);
    }
}
