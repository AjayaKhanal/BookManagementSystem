using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions.Dto
{
    [AutoMapFrom(typeof(Suggestion))]
    public class SuggestionDto : EntityDto<int>
    {
        [Required]
        public string SuggestionDescription { get; set; }

        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
