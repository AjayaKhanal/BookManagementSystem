using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows
{
    public class BookBorrowManager : DomainService, IBookBorrowManager
    {
        private readonly IRepository<BookBorrow> _bookBorrowRepository;

        public BookBorrowManager(IRepository<BookBorrow> bookBorrowRepository)
        {
            _bookBorrowRepository = bookBorrowRepository;
        }

        public async Task CreateBookBorrowAsync(BookBorrow bookBorrow)
        {
            await _bookBorrowRepository.InsertAsync(bookBorrow);
        }

        public async Task<List<BookBorrow>> GetBookBorrowAsync()
        {
            return await _bookBorrowRepository.GetAllListAsync();
        }

        public async Task<BookBorrow> GetBookBorrowByIdAsync(int id)
        {
            return await _bookBorrowRepository.GetAsync(id);
        }

        public async Task UpdateBookBorrowAsync(BookBorrow bookBorrow)
        {
            await _bookBorrowRepository.UpdateAsync(bookBorrow);
        }
    }
}
