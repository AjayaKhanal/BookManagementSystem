using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Books.Dto
{
    [AutoMapFrom(typeof(Book))]
    public class BookDto : EntityDto<int>
    {
        [Required]
        public string BookName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public string CreatedBy { get; set; }

    }
}
