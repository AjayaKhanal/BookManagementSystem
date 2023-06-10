using Abp.Application.Services.Dto;
using BookManagementSystem.ForumReplies;
using BookManagementSystem.Forums;
using BookManagementSystem.Forums.Dto;
using BookManagementSystem.Models.Forums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Controllers
{
    public class ForumsController : BookManagementSystemControllerBase
    {
        private readonly IForumAppService _forumAppService;
        private readonly IForumReplyAppService _forumReplyAppService;

        public ForumsController(
            IForumAppService forumAppService,
            IForumReplyAppService forumReplyAppService)
        {
            _forumAppService = forumAppService;
            _forumReplyAppService = forumReplyAppService;
        }

        public async Task<IActionResult> Index(PagedForumResultRequestDto input)
        {
            var forum = (await _forumAppService.GetAllAsync(input)).Items;
            var model = new ForumListViewModel
            {
                Forum = forum
            };

            return View(model);
        }

        public async Task<IActionResult> ForumDetails(int id)
        {
            var forumDetails = await _forumAppService.GetAsync(new EntityDto<int>(id));

            var model = new ForumDetailsViewModel { 
                Forum = forumDetails
            };
            return View(model);
        }
    }
}
