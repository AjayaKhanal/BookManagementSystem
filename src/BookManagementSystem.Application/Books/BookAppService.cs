using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.Authors;
using BookManagementSystem.Authors.Dto;
using BookManagementSystem.BookAuthors;
using BookManagementSystem.Books.Dto;
using BookManagementSystem.BooksAuthors.Dto;
using BookManagementSystem.Web.Hubs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Books
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly BookManager _bookManager;
        private readonly AuthorManager _authorManager;
        private readonly BookAuthorManager _bookAuthorManager;
        private readonly IRepository<BookAuthor> _bookAuthorRepository;
        private readonly INotificationPublisher _notificationManager;
        private readonly INotificationStore _notificationStore;

        public BookAppService(
            IRepository<Book, int> repository,
            IRepository<BookAuthor> bookAuthorRepository,
            BookManager bookManager,
            AuthorManager authorManager,
            BookAuthorManager bookAuthorManager,
            INotificationPublisher notificationManager,
            INotificationStore notificationStore,
            IHubContext<NotificationHub> hubContext
            )
            : base(repository)
        {
            _bookManager = bookManager;
            _authorManager = authorManager;
            _bookAuthorManager = bookAuthorManager;
            _bookAuthorRepository = bookAuthorRepository;
            _notificationManager = notificationManager;
            _notificationStore = notificationStore;
            _hubContext = hubContext;
        }

        public async Task<BooksAuthorsDto> CreateBookAndAuthorsAsync(CreateBookAuthorDto input)
        {
            CheckCreatePermission();
            var author = await _authorManager.GetAuthorByIdAsync(input.Author.Id);

            // Create a new book entity
            var book = new Book
            {
                BookName = input.Book.BookName,
                Quantity = input.Book.Quantity,
                Description = input.Book.Description
            };
            book.CreationTime = Clock.Now;
            book.CreatorUserId = AbpSession.GetUserId();
            await _bookManager.CreateBookAsync(book);

            // Save changes to the repository
            await CurrentUnitOfWork.SaveChangesAsync();

            var bookAuthor = new BookAuthor
            {
                AuthorId = input.Author.Id,
                BookId = book.Id
            };
            await _bookAuthorManager.CreateBookAuthorAsync(bookAuthor);

            // Save changes to the repository
            await CurrentUnitOfWork.SaveChangesAsync();

            var notification = "New book " + book.BookName + " is added";
            NotificationInfo notificationInfo = new NotificationInfo
            {
                Data = notification,
                CreationTime = Clock.Now,
                CreatorUserId = AbpSession.GetUserId(),
                NotificationName = notification,
                Severity = NotificationSeverity.Success
            };

            await _notificationStore.InsertNotificationAsync(notificationInfo);

            await _notificationManager.PublishAsync(notification, severity: notificationInfo.Severity);

            await CurrentUnitOfWork.SaveChangesAsync();

            // Send the SignalR notification to all connected clients in the user's group
            var userId = AbpSession.GetUserId();
            if (userId != default(long))
            {
                await _hubContext.Clients.Group(GetSignalRGroupName(userId)).SendAsync(
                    "ReceiveNotification",
                    notificationInfo.Id.ToString(),
                    notificationInfo.CreationTime,
                    notificationInfo.Severity.ToString().ToLower(),
                    notificationInfo.Data.ToString(),
                    "",
                    GetSignalRGroupName(userId));
                //await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
            }

            return new BooksAuthorsDto
            {
                AuthorId = author.Id,
                BookId = book.Id
            };

        }

        private string GetSignalRGroupName(long userId)
        {
            return $"User:{userId}";
        }

        public async Task<BooksAuthorsDto> UpdateBookAndAuthors(BooksAuthorsDto input)
        {
            CheckUpdatePermission();
            var book = await _bookManager.GetBookByIdAsync(input.Book.Id);

            book.BookName = input.Book.BookName;
            book.Quantity = input.Book.Quantity;
            book.Description = input.Book.Description;

            //update book
            await _bookManager.UpdateBookAsync(book);

            var bookAuthor = await _bookAuthorManager.GetAll();
            var author = bookAuthor.FirstOrDefault(ba => ba.BookId == input.Book.Id);

            author.AuthorId = input.Author.Id;
            author.BookId = input.Book.Id;

            //update book author
            await _bookAuthorManager.UpdateBookAuthorAsync(author);

            return new BooksAuthorsDto
            {
                AuthorId = input.Author.Id,
                BookId = book.Id
            };
        }

        public async Task<ListResultDto<BookDto>> GetBooksAsync()
        {
            var books = await _bookManager.GetBookAsync();

            return new ListResultDto<BookDto>(ObjectMapper.Map<List<BookDto>>(books));
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            await _bookManager.DeleteBookAsync(input.Id);

            var bookAuthorDetails = await _bookAuthorManager.GetAll();
            var bookAuthor = bookAuthorDetails.FirstOrDefault(ba => ba.BookId == input.Id);
            var books = await _bookManager.GetBookAsync();
            var book = books.FirstOrDefault(b => b.Id == input.Id);

            await _bookAuthorManager.DeleteBookAuthorAsync(bookAuthor.Id);

            var notification = book.BookName + " book is deleted";
            NotificationInfo notificationInfo = new NotificationInfo
            {
                Data = notification,
                CreationTime = Clock.Now,
                CreatorUserId = AbpSession.GetUserId(),
                NotificationName = notification,
                Severity = NotificationSeverity.Success
            };
            await _notificationStore.InsertNotificationAsync(notificationInfo);

            await _notificationManager.PublishAsync(notification, severity: notificationInfo.Severity);

            // Save changes to the repository
            await CurrentUnitOfWork.SaveChangesAsync();

            // Send the SignalR notification to all connected clients in the user's group
            var userId = AbpSession.GetUserId();
            if (userId != default(long))
            {
                await _hubContext.Clients.Group(GetSignalRGroupName(userId)).SendAsync(
                    "ReceiveNotification",
                    notificationInfo.Id.ToString(),
                    notificationInfo.CreationTime,
                    notificationInfo.Severity.ToString().ToLower(),
                    notificationInfo.Data.ToString(),
                    "",
                    GetSignalRGroupName(userId));
                //await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
            }
        }

        public async Task<BooksAuthorsDto> GetAuthorAndBooksAsync(int authorId)
        {
            var author = await _bookAuthorRepository.GetAll()
                .Include(ba => ba.Book)
                .Where(ba => ba.Author.Id == authorId)
                .Select(ba => ba.Author)
                .FirstOrDefaultAsync();

            var books = await _bookAuthorRepository.GetAll()
                .Include(ba => ba.Book)
                .Where(ba => ba.Author.Id == authorId)
                .Select(ba => ba.Book)
                .ToListAsync();

            var authorDto = ObjectMapper.Map<AuthorDto>(author);
            var bookDto = ObjectMapper.Map<BookDto>(books);

            return new BooksAuthorsDto() { Author = authorDto, Book = bookDto };
        }

        protected override IQueryable<Book> CreateFilteredQuery(PagedBookResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.BookName.Contains(input.Keyword));
        }

        protected override IQueryable<Book> ApplySorting(IQueryable<Book> query, PagedBookResultRequestDto input)
        {
            return query.OrderBy(x => x.BookName);
        }

    }
}
