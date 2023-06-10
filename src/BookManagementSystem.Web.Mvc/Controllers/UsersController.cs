using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using BookManagementSystem.Authorization;
using BookManagementSystem.Controllers;
using BookManagementSystem.Users;
using BookManagementSystem.Web.Models.Users;
using System.Linq;
using Abp.Runtime.Session;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Abp.Authorization;
using Abp.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using BookManagementSystem.Authorization.Users;
using System.Threading;

namespace BookManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : BookManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;
        //private readonly IRepository<UserRole> _userRoleRepository;
        //private readonly IUserRoleStore<User> _userRoleStore;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
            
        }

        public async Task<ActionResult> Index()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(long userId)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return PartialView("_EditModal", model);
        }

        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> MyProfile()
        {
            var currentUser = AbpSession.GetUserId();
            var current = new EntityDto<long> { Id = currentUser };
            var user = await _userAppService.GetAsync(current);
            
            var model = new UserDetailsViewModel
            {
                Users = user
            };
            return View(model);
        }
    }
}
