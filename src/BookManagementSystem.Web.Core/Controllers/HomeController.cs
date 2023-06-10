using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BookManagementSystem.Controllers;
using BookManagementSystem.EBooks;
using System.Threading.Tasks;
using BookManagementSystem.Models.EBooks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using BookManagementSystem.EBookAuthors;
using Microsoft.EntityFrameworkCore;
using BookManagementSystem.Authors;
using BookManagementSystem.EBookAuthors.Dto;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using BookManagementSystem.EBooks.Dto;

namespace BookManagementSystem.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BookManagementSystemControllerBase
    {
        private readonly IEBookAppService _eBookAppService;
        private readonly IRepository<EBookAuthor> _eBookAuthorRepository;
        private readonly IAuthorAppService _authorAppService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(
            IEBookAppService eBookAppService,
            IRepository<EBookAuthor> eBookAuthorRepository,
            IAuthorAppService authorAppService,
            IWebHostEnvironment hostingEnvironment)
        {
            _eBookAppService = eBookAppService;
            _eBookAuthorRepository = eBookAuthorRepository;
            _authorAppService = authorAppService;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> Index(PagedEBookResultRequestDto input)
        {
            var ebook = (await _eBookAppService.GetAllAsync(input)).Items;
            var model = new EBookListViewModel { 
                EBook = ebook
            };
            return View(model);
        }

        public async Task<IActionResult> EBook(int id)
        {
            var ebookDetails = (await _eBookAppService.GetAsync(new EntityDto<int>(id)));
            var ebookAuthorDetails = await _eBookAuthorRepository.GetAll()
                .FirstOrDefaultAsync(eba => eba.EBookId == id);
            var authorDetails = await _authorAppService.GetAsync(new EntityDto<int>(ebookAuthorDetails.AuthorId));

            var model = new EBookDetailsViewModel
            {
                EBook = ebookDetails,
                Author = authorDetails,
                EBookAuthor = new EBookAuthorsDto
                {
                    AuthorId = ebookAuthorDetails.AuthorId,
                    EBookId = ebookDetails.Id
                }
            };
            return View(model);
        }

        public async Task<IActionResult> ViewPdf(int id)
        {
            var ebook = await _eBookAppService.GetAsync(new EntityDto<int>(id));
            var filePath = ebook.FilePath;

            try
            {
                var absolutePath = Path.Combine(_hostingEnvironment.WebRootPath, filePath);
                //using (var stream = new FileStream(absolutePath, FileMode.Open, FileAccess.Read))
                //{
                //    return new FileStreamResult(stream, "application/pdf");
                //}
                var bytes = await System.IO.File.ReadAllBytesAsync(absolutePath);
                return new FileContentResult(bytes, "application/pdf");
            }
            catch (Exception ex)
            {
                // Log the error or handle it in some other way
                return NotFound();
            }
        }

    }
}
