using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks.Dto
{
    [AutoMapFrom(typeof(EBook))]
    public class EBookDto : EntityDto<int>
    {
        public string EBookName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FilePath { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
