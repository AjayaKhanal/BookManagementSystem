using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Forums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.ForumReplies
{
    public class ForumReply : FullAuditedEntity<int>
    {
        [Required]
        public string ReplyDescripion { get; set; }

        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
