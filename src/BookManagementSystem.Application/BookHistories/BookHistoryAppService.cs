using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.BookHistories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using BookManagementSystem.EBooks;
using BookManagementSystem.EBooks.Dto;

namespace BookManagementSystem.BookHistories
{
    public class BookHistoryAppService : AsyncCrudAppService<BookHistory, BookHistoryDto, int, PagedBookHistoryResultRequestDto, CreateBookHistoryDto, BookHistoryDto>, IBookHistoryAppService
    {
        private readonly IBookHistoryManager _bookHistoryManager;
        private readonly IEBookManager _eBookManager;

        public BookHistoryAppService(
            IRepository<BookHistory, int> repository,
            IBookHistoryManager bookHistoryManager,
            IEBookManager eBookManager
            ) : base(repository)
        {
            _bookHistoryManager = bookHistoryManager;
            _eBookManager = eBookManager;
        }

        public async Task<ListResultDto<BookHistoryDto>> GetAllAsync(int userId)
        {
            var bookHistory = await _bookHistoryManager.GetAllAsync();
            var bookHistoryDetails = bookHistory
                .Where(bh => bh.UserId == userId)
                .GroupBy(bh => bh.EBookId)
                .Select(group => group.OrderByDescending(bh => bh.Id).First())
                .ToList();

            // Load eBook details for each book history entry
            foreach (var historyDto in bookHistoryDetails)
            {
                var ebook = await _eBookManager.GetEBooksByIdAsync(historyDto.EBookId);
                historyDto.EBook = ObjectMapper.Map<EBook>(ebook);
            }

            return new ListResultDto<BookHistoryDto>(ObjectMapper.Map<List<BookHistoryDto>>(bookHistoryDetails));

        }

        public async Task<BookHistoryDto> CreateAsync(CreateBookHistoryDto input)
        {
            CheckCreatePermission();

            var bookHistory = new BookHistory()
            {
                EBookId = input.EBookId,
                UserId = AbpSession.GetUserId()
            };
            bookHistory.CreationTime = Clock.Now;
            bookHistory.CreatorUserId = AbpSession.GetUserId();
            await _bookHistoryManager.CreateAsync(bookHistory);
            await CurrentUnitOfWork.SaveChangesAsync();

            return new BookHistoryDto()
            {
                EBookId = input.EBookId,
                UserId = AbpSession.GetUserId(),
                CreationTime = Clock.Now,
                CreatedBy = AbpSession.GetUserId().ToString()
            };
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            await _bookHistoryManager.DeleteAsync(input.Id);
        }
    }
}
