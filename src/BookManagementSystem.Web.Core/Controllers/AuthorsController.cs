using Abp.Application.Services.Dto;
using BookManagementSystem.Authors;
using BookManagementSystem.Models.Authors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class AuthorsController : BookManagementSystemControllerBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorsController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        public async Task<IActionResult> Index()
        {
            var author = (await _authorAppService.GetAuthorsAsync()).Items;
            var model = new AuthorListViewModel
            {
                Author = author
            };

            return View(model);

        }

        public async Task<ActionResult> EditModal(int authorId)
        {
            var output = await _authorAppService.GetAsync(new EntityDto<int>(authorId));
            //var model = ObjectMapper.Map<EditAuthorModalViewModel>(output);

            var model = new EditAuthorModalViewModel() { Author = output};

            return PartialView("_EditModal", model);
        }

    }
}
