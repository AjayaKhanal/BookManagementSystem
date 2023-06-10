using Abp.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors.Dto
{
    public class CreateAuthorDto
    {
        [Required]
        [StringLength(AbpRoleBase.MaxNameLength)]
        public string AuthorName { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatorUserId { get; set; }
    }
}
