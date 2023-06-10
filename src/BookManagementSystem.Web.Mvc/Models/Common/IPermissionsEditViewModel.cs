using System.Collections.Generic;
using BookManagementSystem.Roles.Dto;

namespace BookManagementSystem.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}