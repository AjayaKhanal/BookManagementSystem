using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BookManagementSystem.Controllers
{
    public abstract class BookManagementSystemControllerBase: AbpController
    {
        protected BookManagementSystemControllerBase()
        {
            LocalizationSourceName = BookManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
