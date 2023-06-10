using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using BookManagementSystem.Authorization;

namespace BookManagementSystem.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class BookManagementSystemNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                )

                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Books,
                        L("Books"),
                        url: "Books",
                        icon: "fas fa-solid fa-book",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Books)
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Authors,
                        L("Authors"),
                        url: "Authors",
                        icon: "fas fa-users",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Authors)
                    )
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.EBooks,
                        L("EBooks"),
                        url: "EBooks",
                        icon: "fas fa-solid fa-book",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_EBooks)
                    )
                )
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.BookBorrows,
                        L("BookBorrow"),
                        url: "BookBorrows",
                        icon: "fas fa-turn-down-right",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_BookBorrows)
                    )
                    )
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.BookReturns,
                        L("BookReturn"),
                        url: "BookReturns",
                        icon: "fas fa-turn-down-left",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_BookReturns)
                    ))
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.Forums,
                        L("Forums"),
                        url: "Forums",
                        icon: "fas fa-turn-down-left"
                    ))
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.BookReports,
                        L("BookReports"),
                        url: "BookReports",
                        icon: "fas fa-turn-down-left",
                    permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_BookReports)
                    )
                )
                 .AddItem(
                    new MenuItemDefinition(
                        PageNames.Suggestion,
                        L("Suggestions"),
                        url: "Suggestions",
                        icon: "fas fa-turn-down-left"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.RecentReadBook,
                        L("RecentReadBook"),
                        url: "BookHistory",
                        icon: "fas fa-turn-down-left"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BookManagementSystemConsts.LocalizationSourceName);
        }
    }
}