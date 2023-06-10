using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookBorrows.Dto
{
    // custom paged result request dto
    public class PagedBookBorrowResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
