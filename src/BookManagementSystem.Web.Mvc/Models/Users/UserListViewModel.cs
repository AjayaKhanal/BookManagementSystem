using System.Collections.Generic;
using BookManagementSystem.Roles.Dto;

namespace BookManagementSystem.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
