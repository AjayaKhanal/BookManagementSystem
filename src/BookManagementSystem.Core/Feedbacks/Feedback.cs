using Abp.Domain.Entities.Auditing;
using BookManagementSystem.Books;
using BookManagementSystem.EBooks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks
{
    public class Feedback : FullAuditedEntity<int>
    {
        [Required]
        public string FeedbackDescription { get; set; }

        public int BookId { get; set;}
        public Book Book { get; set; }

    }
}
