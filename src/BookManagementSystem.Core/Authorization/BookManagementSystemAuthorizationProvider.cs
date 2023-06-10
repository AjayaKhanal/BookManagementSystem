using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace BookManagementSystem.Authorization
{
    public class BookManagementSystemAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Authors, L("Authors"));
            context.CreatePermission(PermissionNames.Pages_Books, L("Books"));
            context.CreatePermission(PermissionNames.Pages_EBooks, L("EBooks"));
            context.CreatePermission(PermissionNames.Pages_BookBorrows, L("BookBorrow"));
            context.CreatePermission(PermissionNames.Pages_BookReturns, L("BookReturn"));
            context.CreatePermission(PermissionNames.Pages_BookReports, L("BookReports"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BookManagementSystemConsts.LocalizationSourceName);
        }
    }
}
