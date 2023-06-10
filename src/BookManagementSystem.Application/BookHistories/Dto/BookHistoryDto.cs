using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.BookAuthors;
using BookManagementSystem.EBookAuthors;
using BookManagementSystem.EBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.BookHistories.Dto
{
    [AutoMapFrom(typeof(BookHistory))]
    public class BookHistoryDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public int EBookId { get; set; }
        public EBook EBook { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
