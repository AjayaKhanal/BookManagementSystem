using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.ForumReplies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies
{
    public class ForumReplyAppService : AsyncCrudAppService<ForumReply, ForumReplyDto, int, PagedForumRequestDto, CreateForumReplyDto, ForumReplyDto>, IForumReplyAppService
    {
        private readonly IForumReplyManager _forumReplyManager;

        public ForumReplyAppService(
            IRepository<ForumReply, int> repository,
            IForumReplyManager forumReplyManager) : base(repository)
        {
            _forumReplyManager = forumReplyManager;
        }
        
        public override async Task<ForumReplyDto> CreateAsync(CreateForumReplyDto input)
        {
            CheckCreatePermission();

            var forumReply = new ForumReply() { 
                ReplyDescripion = input.ReplyDescription,
                ForumId = input.ForumId
            };
            forumReply.CreationTime = Clock.Now;
            forumReply.CreatorUserId = AbpSession.GetUserId();

            await _forumReplyManager.CreateForumReplyAsync(forumReply);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new ForumReplyDto() {
                ReplyDescripion = input.ReplyDescription,
                ForumId = input.ForumId,
                CreationTime = Clock.Now,
                CreatedBy = AbpSession.GetUserId().ToString()
            };
        }

        public async Task<ListResultDto<ForumReplyDto>> GetForumReplyAsync(int id)
        {
            var forumReplyDetails = await _forumReplyManager.GetForumReplyAsync();
            var forumReplies = forumReplyDetails.Where(fr => fr.ForumId == id);

            return new ListResultDto<ForumReplyDto>(ObjectMapper.Map<List<ForumReplyDto>>(forumReplies.ToList()));

        }
    }
}
