using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BookManagementSystem.EBooks;
using BookManagementSystem.EBooksFeedback;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookFeedbacks.Dto
{
    [AutoMapFrom(typeof(EBookFeedback))]
    public class EBookFeedbackDto : EntityDto<int>
    {
        [Required]
        public string FeedbackDescription { get; set; }

        public int EBookId { get; set; }
        public EBook EBook { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
