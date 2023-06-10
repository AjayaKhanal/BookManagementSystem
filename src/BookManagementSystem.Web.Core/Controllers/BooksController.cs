using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Repositories;
using BookManagementSystem.Authorization;
using BookManagementSystem.Authors;
using BookManagementSystem.BookAuthors;
using BookManagementSystem.Books;
using BookManagementSystem.Books.Dto;
using BookManagementSystem.BooksAuthors.Dto;
using BookManagementSystem.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    //[AbpMvcAuthorize(PermissionNames.Pages_Books)]
    public class BooksController : BookManagementSystemControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IRepository<BookAuthor> _bookAuthorRepository;
        private readonly IAuthorAppService _authorAppService;

        public BooksController(
            IBookAppService bookAppService,
            IAuthorAppService authorAppService,
            IRepository<BookAuthor> bookAuthorRepository)
        {
            _bookAppService = bookAppService;
            _bookAuthorRepository = bookAuthorRepository;
            _authorAppService = authorAppService;
        }

        public async Task<IActionResult> Index()
        {
            var book = (await _bookAppService.GetBooksAsync()).Items;
            var model = new BookListViewModel
            {
                Book = book
            };

            return View(model);
        }

        public async Task<IActionResult> EditModal(int Id)
        {
            var book = await _bookAppService.GetAsync(new EntityDto<int>(Id));
            var bookAuthor = await _bookAuthorRepository.GetAll()
                .FirstOrDefaultAsync(ba => ba.BookId == Id);

            //var model = ObjectMapper.Map<EditBookModalViewModel>(output);
            var model = new EditBookModalViewModel
            {
                Book = book,
                BookAuthor = new BooksAuthorsDto
                {
                    BookId = book.Id,
                    AuthorId = bookAuthor.AuthorId
                }
            };

            return PartialView("_EditModal", model);
        }

        public async Task<IActionResult> BookDetails(int id)
        {
            var bookDetails = await _bookAppService.GetAsync(new EntityDto<int>(id));
            var bookAuthorDetails = await _bookAuthorRepository.GetAll()
                .FirstOrDefaultAsync(ba => ba.BookId == id);
            var authorDetails = await _authorAppService.GetAsync(new EntityDto<int>(bookAuthorDetails.AuthorId));


            var model = new BookDetailsViewModel
            {
                Book = bookDetails,
                Author = authorDetails,
                BookAuthor = new BooksAuthorsDto
                {
                    BookId = bookDetails.Id,
                    AuthorId = bookAuthorDetails.AuthorId
                }
            };

            return View(model);
        }

        public async Task<JsonResult> GetAuthors()
        {
            var authors = await _authorAppService.GetAuthorsAsync();
            var authorList = authors.Items.Select(a => new { id = a.Id, authorName = a.AuthorName });
            return Json(authorList);
        }
    }
}
