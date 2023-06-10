using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.ForumReplies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies
{
    public interface IForumReplyAppService: IAsyncCrudAppService<ForumReplyDto,int, PagedForumRequestDto,CreateForumReplyDto, ForumReplyDto>
    {
        Task<ForumReplyDto> CreateAsync(CreateForumReplyDto input);
        Task<ListResultDto<ForumReplyDto>> GetForumReplyAsync(int id);
    }
}
