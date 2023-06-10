using BookManagementSystem.BookBorrows;
using BookManagementSystem.Books;
using BookManagementSystem.Models.BookBorrows;
using BookManagementSystem.Models.BookReports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class BookReportsController : BookManagementSystemControllerBase
    {
        private readonly IBookBorrowAppService _bookBorrowAppService;
        private readonly IBookAppService _bookAppService;
        public BookReportsController(
            IBookBorrowAppService bookBorrowAppService,
            IBookAppService bookAppService)
        {
            _bookBorrowAppService = bookBorrowAppService;
            _bookAppService = bookAppService;
        }

        public async Task<IActionResult> Index()
        {
            var bookBorrowsResult = await _bookBorrowAppService.GetAllAsync();
            var bookBorrows = bookBorrowsResult.Items;
            var booksResult = await _bookAppService.GetBooksAsync();
            var books = booksResult.Items;
            var bookReports = new List<BookReportViewModel>();

            foreach (var book in books)
            {
                var bookBorrowedCount = bookBorrows.Count(b => b.BookId == book.Id);
                var bookReport = new BookReportViewModel
                {
                    BookName = book.BookName,
                    BookBorrowed = bookBorrowedCount,
                    Quantity = book.Quantity
                };

                bookReports.Add(bookReport);
            }

            return View(bookReports);
        }

    }
}

