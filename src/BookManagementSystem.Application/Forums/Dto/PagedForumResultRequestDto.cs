using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Forums.Dto
{
    public class PagedForumResultRequestDto : PagedResultRequestDto
    {
        public string keyword { get; set; }
    }
}
