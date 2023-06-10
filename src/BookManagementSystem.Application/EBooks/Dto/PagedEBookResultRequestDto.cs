using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks.Dto
{
    //custom PagedResultRequestDto
    public class PagedEBookResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
