using Abp;
using Abp.Application.Services.Dto;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.Authors;
using BookManagementSystem.Books;
using BookManagementSystem.Users;
using BookManagementSystem.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class BookBorrowsController : BookManagementSystemControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IAuthorAppService _authorAppService;
        private readonly IUserAppService _userAppService;

        public BookBorrowsController(
            IBookAppService bookAppService,
            IAuthorAppService authorAppService,
            IUserAppService userAppService)
        {
            _bookAppService = bookAppService;
            _authorAppService = authorAppService;
            _userAppService = userAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> GetBooks()
        {
            var books = await _bookAppService.GetBooksAsync();
            var booksList = books.Items.Select(a => new { Id = a.Id, BookName = a.BookName });
            return Json(booksList);
        } 

        public async Task<JsonResult> GetAuthors()
        {
            var authors = await _authorAppService.GetAuthorsAsync();
            var authorsList = authors.Items.Select(a => new { Id = a.Id, AuthorName = a.AuthorName });
            return Json(authorsList);
        }

        public async Task<JsonResult> GetEmails()
        {
            var request = new PagedUserResultRequestDto();
            var emails = await _userAppService.GetAllAsync(request);
            var emailsList = emails.Items.Select(a => new { Id = a.Id, Email = a.EmailAddress });
            return Json(emailsList);
        }

        public async Task<JsonResult> GetStudentName(int id)
        {
            var entityDto = new EntityDto<long> { 
                Id = id
            };
            var user = await _userAppService.GetAsync(entityDto);
            if (user != null)
            {
                return Json(new {StudentName = user.UserName });
            }
            return Json(new { StudentName = "" });
        }
    }
}
