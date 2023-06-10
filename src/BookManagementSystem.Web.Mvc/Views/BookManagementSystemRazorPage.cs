using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BookManagementSystem.Web.Views
{
    public abstract class BookManagementSystemRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BookManagementSystemRazorPage()
        {
            LocalizationSourceName = BookManagementSystemConsts.LocalizationSourceName;
        }
    }
}
