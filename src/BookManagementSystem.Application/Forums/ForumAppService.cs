using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Forums.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Extensions;

namespace BookManagementSystem.Forums
{
    public class ForumAppService : AsyncCrudAppService<Forum, ForumDto, int, PagedForumResultRequestDto, CreateForumDto, ForumDto>, IForumAppService
    {
        public readonly ForumManager _forumManager;

        public ForumAppService(
            IRepository<Forum, int> repository,
            ForumManager forumManager
            ) : base(repository)
        {
            _forumManager = forumManager;
        }

        public override async Task<ForumDto> CreateAsync(CreateForumDto input)
        {
            CheckCreatePermission();

            var forum = new Forum
            {
                Title = input.Title,
                Description = input.Description
            };

            forum.CreationTime = Clock.Now;
            forum.CreatorUserId = AbpSession.GetUserId();
            await _forumManager.CreateForumAsync(forum);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new ForumDto
            {
                Title = input.Title,
                Description = input.Description,
                CreationTime = Clock.Now,
                CreatedBy = AbpSession.GetUserId().ToString()
            };
        }

        public override async Task<ForumDto> UpdateAsync(ForumDto input)
        {
            CheckUpdatePermission();
            var forum = await _forumManager.GetForumByIdAsync(input.Id);

            //ObjectMapper.Map(input, forum);
            forum.Title = input.Title;
            forum.Description = input.Description;

            await _forumManager.UpdateForumAsync(forum);

            //return MapToEntityDto(forum);
            return new ForumDto {
                Title = input.Title,
                Description = input.Description
            };
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            await _forumManager.DeleteForumAsync(input.Id);
        }

        public async Task<ListResultDto<ForumDto>> GetForumAsync()
        {
            var forums = await _forumManager.GetForumAsync();

            return new ListResultDto<ForumDto>(ObjectMapper.Map<List<ForumDto>>(forums));
        }

        protected override IQueryable<Forum> CreateFilteredQuery(PagedForumResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.keyword.IsNullOrWhiteSpace(), x => x.Title.Contains(input.keyword));
        }

        protected override IQueryable<Forum> ApplySorting(IQueryable<Forum> query, PagedForumResultRequestDto input)
        {
            return query.OrderBy(x => x.Title);
        }
    }
}
