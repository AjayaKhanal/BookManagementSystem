using System.Collections.Generic;
using BookManagementSystem.Roles.Dto;

namespace BookManagementSystem.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
