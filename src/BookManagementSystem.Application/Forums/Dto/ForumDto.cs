using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Forums.Dto
{
    [AutoMapFrom(typeof(Forum))]
    public class ForumDto : EntityDto<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
