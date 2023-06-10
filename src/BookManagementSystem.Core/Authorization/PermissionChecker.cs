using Abp.Authorization;
using BookManagementSystem.Authorization.Roles;
using BookManagementSystem.Authorization.Users;

namespace BookManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
