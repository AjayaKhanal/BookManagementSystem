using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks.Dto
{
    [AutoMapFrom(typeof(Feedback))]
    public class FeedbackDto : EntityDto<int>
    {
        [Required]
        public string FeedbackDescription { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationTime { get; set; }
    }
}

