using Abp.Application.Services.Dto;
using BookManagementSystem.Authors;
using BookManagementSystem.EBookAuthors;
using BookManagementSystem.EBookAuthors.Dto;
using BookManagementSystem.EBooks;
using BookManagementSystem.Models.EBooks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class EBooksController : BookManagementSystemControllerBase
    {
        private readonly IEBookAppService _eBookAppService;
        private readonly IAuthorAppService _authorAppService;
        private readonly IEBookAuthorManager _ebookAuthorManager;

        public EBooksController(
            IEBookAppService eBookAppService, 
            IAuthorAppService authorAppService,
            IEBookAuthorManager ebookAuthorManager)
        {
            _eBookAppService = eBookAppService;
            _authorAppService = authorAppService;
            _ebookAuthorManager = ebookAuthorManager;
        }

        public async Task<IActionResult> Index()
        {
            var eBook = (await _eBookAppService.GetEBooksAsync()).Items;
            var model = new EBookListViewModel()
            {
                EBook = eBook
            };
            return View(model);
        }

        public async Task<IActionResult> EditModal(int eBookId)
        {
            var ebook = await _eBookAppService.GetAsync(new EntityDto<int> (eBookId) );
            var ebookAuthorDetails = await _ebookAuthorManager.GetEBookAuthorsAsync();
            var ebookAuthor = ebookAuthorDetails.FirstOrDefault(eba => eba.EBookId == eBookId);

            var model = new EditEBookModalViewModel { 
                EBook = ebook,
                EBookAuthor = new EBookAuthorsDto
                {
                    EBookId = ebook.Id,
                    AuthorId = ebookAuthor.AuthorId
                }
            };
            return PartialView("_EditModal", model);
        }

        public async Task<JsonResult> GetAuthors()
        {
            var authors = await _authorAppService.GetAuthorsAsync();
            var authorList = authors.Items.Select(a => new { Id = a.Id, AuthorName = a.AuthorName }).ToList();
            return Json(authorList);
        }

        public async Task<IActionResult> UploadFile([FromForm] IFormFile filePath)
        {
            try {
                string fileName = filePath.FileName;
                fileName = Path.GetFileName(fileName);
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\EBookFile", fileName);
                var stream = new FileStream(uploadPath, FileMode.Create);
                await filePath.CopyToAsync(stream);

                return Json(new { success = true, message = "File uploaded successfully." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "An error occurred while uploading the file." });
            }
        }

    }
}
