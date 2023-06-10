using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Authors.Dto;
using BookManagementSystem.Authors;
using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementSystem.EBookAuthors.Dto;
using BookManagementSystem.EBookAuthors;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Notifications;
using BookManagementSystem.Books;

namespace BookManagementSystem.EBooks
{
    public class EBookAppService : AsyncCrudAppService<EBook, EBookDto, int, PagedEBookResultRequestDto, CreateEBookDto, EBookDto>, IEBookAppService
    {
        private readonly IEBookManager _eBookManager;
        private readonly IAuthorManager _authorManager;
        private readonly IEBookAuthorManager _ebookAuthorManager;
        private readonly INotificationStore _notificationManager;

        public EBookAppService(
            IRepository<EBook, int> repository,
            IEBookManager eBookManager,
            IAuthorManager authorManager,
            IEBookAuthorManager ebookAuthorManager,
            INotificationStore notificationManager) : base(repository)
        {
            _eBookManager = eBookManager;
            _authorManager = authorManager;
            _ebookAuthorManager = ebookAuthorManager;
            _notificationManager = notificationManager;
        }

        public async Task<ListResultDto<EBookDto>> GetEBooksAsync()
        {
            var eBooks = await _eBookManager.GetEBooksAsync();

            return new ListResultDto<EBookDto>(ObjectMapper.Map<List<EBookDto>>(eBooks));
        }

        public override async Task<EBookDto> CreateAsync(CreateEBookDto input)
        {
            CheckCreatePermission();

            var eBook = new EBook { 
                EBookName = input.EBookName,
                Description = input.Description,
                FilePath = input.FilePath
            };
            eBook.CreationTime = Clock.Now;
            eBook.CreatorUserId = AbpSession.GetUserId();

            await _eBookManager.CreateEBookAsync(eBook);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new EBookDto { 
                EBookName = eBook.EBookName,
                Description = eBook.Description,
                FilePath = eBook.FilePath,
                CreatedBy = eBook.CreatorUserId.ToString(),
                CreationTime = eBook.CreationTime
            };
        }

        public async Task<EBookAuthorsDto> CreateEBookAndAuthorsAsync(CreateEBookAuthorDto input)
        {
            CheckCreatePermission();
            var author = await _authorManager.GetAuthorByIdAsync(input.Author.Id);

            // Create a new ebook entity
            var ebook = new EBook
            {
                EBookName = input.EBook.EBookName,
                Description = input.EBook.Description,
                FilePath = input.EBook.FilePath
            };
            ebook.CreationTime = Clock.Now;
            ebook.CreatorUserId = AbpSession.GetUserId();

            await _eBookManager.CreateEBookAsync(ebook);
            await CurrentUnitOfWork.SaveChangesAsync();

            var ebookAuthor = new EBookAuthor { 
                EBookId = ebook.Id,
                AuthorId = input.Author.Id
            };

            await _ebookAuthorManager.CreateEBookAuthorsAsync(ebookAuthor);

            // Save changes to the repository
            await CurrentUnitOfWork.SaveChangesAsync();

            var notification = "New ebook " + ebook.EBookName + " is added";
            NotificationInfo notificationInfo = new NotificationInfo
            {
                Data = notification,
                CreationTime = Clock.Now,
                CreatorUserId = AbpSession.GetUserId(),
                NotificationName = notification,
                Severity = NotificationSeverity.Success
            };
            await _notificationManager.InsertNotificationAsync(notificationInfo);

            // Save changes to the repository
            await CurrentUnitOfWork.SaveChangesAsync();

            // Map the author and book entities to their DTOs and return as a single AuthorBookDto object
            return new EBookAuthorsDto
            {
                AuthorId = author.Id,
                EBookId = ebook.Id
            };

        }

        public async Task<EBookAuthorsDto> UpdateEBookAuthorsAsync(EBookAuthor input) {
            CheckUpdatePermission();
            var eBook = await _eBookManager.GetEBooksByIdAsync(input.EBook.Id);

            eBook.EBookName = input.EBook.EBookName;
            eBook.Description = input.EBook.Description;
            eBook.FilePath = input.EBook.FilePath;

            await _eBookManager.UpdateEBookAsync(eBook);

            var ebookAuthor = await _ebookAuthorManager.GetEBookAuthorsAsync();
            var author = ebookAuthor.FirstOrDefault(ba => ba.EBookId == input.EBook.Id);

            author.AuthorId = input.Author.Id;
            author.EBookId = eBook.Id;

            await _ebookAuthorManager.UpdateEBookAuthorsAsync(author);

            return new EBookAuthorsDto {
                AuthorId = author.Id,
                EBookId = eBook.Id
            };
        }

        public async Task<EBookDto> UpdateAsync(EBook input)
        {
            CheckUpdatePermission();
            var eBook = await _eBookManager.GetEBooksByIdAsync(input.Id);

            ObjectMapper.Map(input, eBook);

            await _eBookManager.UpdateEBookAsync(eBook);

            return MapToEntityDto(eBook);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            await _eBookManager.DeleteEBookAsync(input.Id);

            var ebookAuthorDetails = await _ebookAuthorManager.GetEBookAuthorsAsync();
            var ebookAuthor = ebookAuthorDetails.FirstOrDefault(ba => ba.EBookId == input.Id);

            var ebooks = await _eBookManager.GetEBooksAsync();
            var ebook = ebooks.FirstOrDefault(b => b.Id == input.Id);

            await _ebookAuthorManager.DeleteEBookAuthorsAsync(ebookAuthor.Id);

            var notification = ebook.EBookName +" is deleted";
            NotificationInfo notificationInfo = new NotificationInfo
            {
                Data = notification,
                CreationTime = Clock.Now,
                CreatorUserId = AbpSession.GetUserId(),
                NotificationName = notification,
                Severity = NotificationSeverity.Success
            };
            await _notificationManager.InsertNotificationAsync(notificationInfo);
        }

        protected override IQueryable<EBook> CreateFilteredQuery(PagedEBookResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.EBookName.Contains(input.Keyword));
        }

        protected override IQueryable<EBook> ApplySorting(IQueryable<EBook> query, PagedEBookResultRequestDto input)
        {
            return query.OrderBy(x => x.EBookName);
        }
    }
}
