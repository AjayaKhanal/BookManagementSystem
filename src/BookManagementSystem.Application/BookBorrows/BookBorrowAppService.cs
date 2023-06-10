using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;
using BookManagementSystem.Authors;
using BookManagementSystem.BookBorrows.Dto;
using BookManagementSystem.Books;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows
{
    public class BookBorrowAppService : AsyncCrudAppService<BookBorrow, BookBorrowDto, int, PagedBookBorrowResultRequestDto, CreateBookBorrowDto, BookBorrowDto>, IBookBorrowAppService
    {
        public readonly IBookBorrowManager _bookBorrowManager;
        public readonly IBookManager _bookManager;
        public readonly IAuthorManager _authorManager;

        public BookBorrowAppService(
            IRepository<BookBorrow, int> repository,
            IBookBorrowManager bookBorrowManager,
            IBookManager bookManager,
            IAuthorManager authorManager) : base(repository)
        {
            _bookBorrowManager = bookBorrowManager;
            _authorManager = authorManager;
            _bookManager = bookManager;
        }

        public override async Task<BookBorrowDto> CreateAsync(CreateBookBorrowDto input)
        {
            CheckCreatePermission();

            var bookDetails = await _bookManager.GetBookAsync();
            var book = bookDetails.FirstOrDefault(b => b.Id == input.BookId);
            if (book.Quantity <= 0)
            {
                throw new UserFriendlyException("The book is not available.");
            }

            var bookBorrow = new BookBorrow
            {
                BookId = input.BookId,
                AuthorId = input.AuthorId,
                UserId = input.UserId
            };

            bookBorrow.CreationTime = Clock.Now;
            bookBorrow.CreatorUserId = AbpSession.GetUserId();
            await _bookBorrowManager.CreateBookBorrowAsync(bookBorrow);
            await CurrentUnitOfWork.SaveChangesAsync();

            book.Quantity--;
            await _bookManager.UpdateBookAsync(book);

            return new BookBorrowDto
            {
                BookId = input.BookId,
                AuthorId = input.AuthorId,
                UserId = input.UserId
            };
        }

        public async Task<ListResultDto<BookBorrowDto>> GetAllAsync()
        {
            var bookBorrows = await _bookBorrowManager.GetBookBorrowAsync();

            return new ListResultDto<BookBorrowDto>(ObjectMapper.Map<List<BookBorrowDto>>(bookBorrows));
        }

        public async Task<List<BookBorrowDto>> GetBookBorrowingDetailsAsync(int id)
        {
            var bookBorrow = await _bookBorrowManager.GetBookBorrowAsync();
            var bookBorrowDetails = bookBorrow.Where(bb => bb.UserId == id && bb.IsReturned == 0);

            var bookBorrowDtos = ObjectMapper.Map<List<BookBorrowDto>>(bookBorrowDetails);

            foreach (var bookBorrowDto in bookBorrowDtos)
            {
                var book = await _bookManager.GetBookByIdAsync(bookBorrowDto.BookId);
                bookBorrowDto.BookName = book.BookName;

                var author = await _authorManager.GetAuthorByIdAsync(bookBorrowDto.AuthorId);
                bookBorrowDto.AuthorName = author.AuthorName;
            }

            return bookBorrowDtos;


        }

        public async Task<BookBorrowDto> BookReturnAsync(int Id)
        {
            var bookBorrow = await _bookBorrowManager.GetBookBorrowByIdAsync(Id);
            bookBorrow.IsReturned = 1;
            await _bookBorrowManager.UpdateBookBorrowAsync(bookBorrow);

            var bookDetails = await _bookManager.GetBookAsync();
            var book = bookDetails.FirstOrDefault(b => b.Id == bookBorrow.BookId);
            book.Quantity++;
            await _bookManager.UpdateBookAsync(book);

            return MapToEntityDto(bookBorrow);
        }
    }
}
