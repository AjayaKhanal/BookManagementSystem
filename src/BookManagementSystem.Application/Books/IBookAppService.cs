using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BookManagementSystem.Books.Dto;
using BookManagementSystem.BooksAuthors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        Task<BookDto> CreateAsync(CreateBookDto input);                                                                             
        Task<BookDto> UpdateAsync(BookDto input);
        Task<ListResultDto<BookDto>> GetBooksAsync();
        Task DeleteAsync(EntityDto<int> input);
        Task<BooksAuthorsDto> CreateBookAndAuthorsAsync(CreateBookAuthorDto input);
    }
}
