using Abp.Domain.Entities.Auditing;
using BookManagementSystem.EBooks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooksFeedback
{
    public class EBookFeedback : FullAuditedEntity<int>
    {
        [Required]
        public string FeedbackDescription { get; set; }

        public int EBookId { get; set; }
        public EBook EBook { get; set; }
    }
}
