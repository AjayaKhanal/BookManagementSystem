﻿using BookManagementSystem.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Feedbacks.Dto
{
    public class FeedbackListDto
    {
        [Required]
        public string FeedbackDescription { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
