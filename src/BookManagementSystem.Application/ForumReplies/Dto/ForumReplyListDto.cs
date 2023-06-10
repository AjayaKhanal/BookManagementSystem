using BookManagementSystem.Forums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies.Dto
{
    public class ForumReplyListDto
    {
        [Required]
        public string ReplyDescription { get; set; }

        public int ForumId { get; set; }
        public Forum Forum { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
