using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.Authors.Dto;
using BookManagementSystem.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors
{
    public interface IAuthorAppService : IAsyncCrudAppService<AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>
    {
        Task<AuthorDto> CreateAsync(CreateAuthorDto input);
        Task<AuthorDto> UpdateAsync(AuthorDto input);
        Task<ListResultDto<AuthorDto>> GetAuthorsAsync();
        Task DeleteAsync(EntityDto<int> input);
    }
}
