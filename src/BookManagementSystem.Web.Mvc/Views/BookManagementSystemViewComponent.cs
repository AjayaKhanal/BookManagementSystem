using Abp.AspNetCore.Mvc.ViewComponents;

namespace BookManagementSystem.Web.Views
{
    public abstract class BookManagementSystemViewComponent : AbpViewComponent
    {
        protected BookManagementSystemViewComponent()
        {
            LocalizationSourceName = BookManagementSystemConsts.LocalizationSourceName;
        }
    }
}
