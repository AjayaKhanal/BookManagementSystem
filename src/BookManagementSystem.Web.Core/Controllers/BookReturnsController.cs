using Abp.Application.Services.Dto;
using BookManagementSystem.Users;
using BookManagementSystem.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class BookReturnsController : BookManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;
        public BookReturnsController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
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
            var entityDto = new EntityDto<long>
            {
                Id = id
            };
            var user = await _userAppService.GetAsync(entityDto);
            if (user != null)
            {
                return Json(new { StudentName = user.UserName });
            }
            return Json(new { StudentName = "" });
        }
    }
}
