using BookManagementSystem.Forums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies.Dto
{
    public class ForumReplyEditDto
    {
        [Required]
        public string ReplyDescription { get; set; }

        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
