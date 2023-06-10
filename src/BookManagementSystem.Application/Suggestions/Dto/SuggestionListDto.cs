using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions.Dto
{
    public class SuggestionListDto
    {
        [Required]
        public string SuggestionDescription { get; set; }
    }
}
