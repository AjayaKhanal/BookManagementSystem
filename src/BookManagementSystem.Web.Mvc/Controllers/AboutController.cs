using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BookManagementSystem.Controllers;

namespace BookManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BookManagementSystemControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
