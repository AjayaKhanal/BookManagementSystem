using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions.Dto
{
    public class AddSuggestionDto
    {
        [Required]
        public string SuggestionDescription { get; set; }

        public string CreatedBy { get; set; }
    }
}
