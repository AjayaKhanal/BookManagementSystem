using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.BookHistories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories
{
    public interface IBookHistoryAppService: IAsyncCrudAppService<BookHistoryDto, int, PagedBookHistoryResultRequestDto, CreateBookHistoryDto, BookHistoryDto>
    {
        Task<BookHistoryDto> CreateAsync(CreateBookHistoryDto input);
        Task<ListResultDto<BookHistoryDto>> GetAllAsync(int userId);
        Task DeleteAsync(EntityDto<int> input);
    }
}
