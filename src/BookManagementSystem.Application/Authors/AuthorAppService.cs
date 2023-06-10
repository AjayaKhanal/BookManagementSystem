using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Authors.Dto;
using BookManagementSystem.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>, IAuthorAppService
    {
        private readonly IAuthorManager _authorManager;

        public AuthorAppService(
            IRepository<Author, int> repository,
            IAuthorManager authorManager)
            : base(repository)
        {
            _authorManager = authorManager;
        }

        public override async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            CheckCreatePermission();

            var author = new Author() { AuthorName = input.AuthorName };
            author.CreationTime = Clock.Now;
            author.CreatorUserId = AbpSession.GetUserId();

            await _authorManager.CreateAuthorAsync(author);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new AuthorDto() { AuthorName = author.AuthorName, CreationTime = author.CreationTime, CreatedBy = author.CreatorUserId.ToString() };
        }

        public override async Task<AuthorDto> UpdateAsync(AuthorDto input)
        {
            CheckUpdatePermission();
            var author = await _authorManager.GetAuthorByIdAsync(input.Id);
            author.AuthorName = input.AuthorName;

            await _authorManager.UpdateAuthorAsync(author);

            return MapToEntityDto(author);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            await _authorManager.DeleteAuthorAsync(input.Id);
        }

        public async Task<ListResultDto<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await _authorManager.GetAuthorAsync();

            return new ListResultDto<AuthorDto>(ObjectMapper.Map<List<AuthorDto>>(authors));
        }

        protected override IQueryable<Author> CreateFilteredQuery(PagedAuthorResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.AuthorName.Contains(input.Keyword));
        }

        protected override IQueryable<Author> ApplySorting(IQueryable<Author> query, PagedAuthorResultRequestDto input)
        {
            return query.OrderBy(x => x.AuthorName);
        }

    }
}
