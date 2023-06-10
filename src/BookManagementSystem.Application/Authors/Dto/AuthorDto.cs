using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors.Dto
{
    [AutoMapFrom(typeof(Author))]
    public class AuthorDto : EntityDto<int>
    {
        
        [StringLength(50)]
        public string AuthorName { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; }
    }
}
