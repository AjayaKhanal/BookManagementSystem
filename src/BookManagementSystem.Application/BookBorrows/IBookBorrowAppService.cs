using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.BookBorrows.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows
{
    public interface IBookBorrowAppService : IAsyncCrudAppService<BookBorrowDto, int, PagedBookBorrowResultRequestDto, CreateBookBorrowDto,BookBorrowDto>
    {
        Task<BookBorrowDto> CreateAsync(CreateBookBorrowDto input);
        Task<ListResultDto<BookBorrowDto>> GetAllAsync();
        Task<List<BookBorrowDto>> GetBookBorrowingDetailsAsync(int id);
    }
}
