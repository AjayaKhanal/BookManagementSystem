using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookAuthors
{
    public class BookAuthorManager : DomainService, IBookAuthorManager
    {
        public readonly IRepository<BookAuthor> _bookAuthorRepository;

        public BookAuthorManager(IRepository<BookAuthor> bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<List<BookAuthor>> GetAll()
        {
            return await _bookAuthorRepository.GetAllListAsync();
        }

        public async Task CreateBookAuthorAsync(BookAuthor bookAuthor)
        {
            await _bookAuthorRepository.InsertAsync(bookAuthor);
        }

        public async Task<BookAuthor> GetAllByIdAsync(int id)
        {
            return await _bookAuthorRepository.GetAsync(id);
        }

        public async Task UpdateBookAuthorAsync(BookAuthor bookAuthor)
        {
            await _bookAuthorRepository.UpdateAsync(bookAuthor);
        }

        public async Task DeleteBookAuthorAsync(int id)
        {
            await _bookAuthorRepository.DeleteAsync(id);
        }
    }
}
