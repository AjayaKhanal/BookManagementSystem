using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookManagementSystem.Forums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies.Dto
{
    [AutoMapFrom(typeof(ForumReply))]
    public class ForumReplyDto : EntityDto<int>
    {
        [Required]
        public string ReplyDescripion { get; set; }

        public int ForumId { get; set; }
        public Forum Forum { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
