using Abp.Runtime.Session;
using BookManagementSystem.BookHistories;
using BookManagementSystem.BookHistories.Dto;
using BookManagementSystem.Models.BookHistory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class BookHistoryController : BookManagementSystemControllerBase
    {
        public readonly IBookHistoryAppService _bookHistoryAppService;

        public BookHistoryController(IBookHistoryAppService bookHistoryAppService)
        {
            _bookHistoryAppService = bookHistoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = (int)AbpSession.GetUserId();
            var bookHistory = (await _bookHistoryAppService.GetAllAsync(userId)).Items;
            var sortedBookHistory = bookHistory.OrderByDescending(bh => bh.Id).ToList();
            var model = new BookHistoryViewModel
            {
                BookHistory = sortedBookHistory
            };
            return View(model);
        }

        public async Task<IActionResult> Create(int userId, int ebookId)
        {
            var bookHistory = new CreateBookHistoryDto()
            {
                UserId = userId,
                EBookId = ebookId
            };
            // Save the BookHistory object using the BookHistoryAppService
            await _bookHistoryAppService.CreateAsync(bookHistory);

            // Redirect to the other controller's action method that will display the book
            return RedirectToAction("Details", "Book", new { id = ebookId });
            
        }
    }
}
