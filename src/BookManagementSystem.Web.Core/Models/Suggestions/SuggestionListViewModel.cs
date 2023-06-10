using BookManagementSystem.Suggestions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.Suggestions
{
    public class SuggestionListViewModel
    {
        public IReadOnlyList<SuggestionDto> Suggestion { get; set; }
    }
}
