using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.Forums.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Forums
{
    public interface IForumAppService : IAsyncCrudAppService<ForumDto, int, PagedForumResultRequestDto, CreateForumDto, ForumDto>
    {
        Task<ForumDto> CreateAsync(CreateForumDto input);
        Task<ForumDto> UpdateAsync(ForumDto input);
        Task DeleteAsync(EntityDto<int> input);
        Task<ListResultDto<ForumDto>> GetForumAsync();
    }
}
