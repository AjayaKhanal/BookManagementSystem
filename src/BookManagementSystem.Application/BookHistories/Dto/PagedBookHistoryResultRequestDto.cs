using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories.Dto
{
    public class PagedBookHistoryResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
