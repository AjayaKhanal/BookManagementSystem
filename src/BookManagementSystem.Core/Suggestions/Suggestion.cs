using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Suggestions
{
    public class Suggestion : FullAuditedEntity<int>
    {
        [Required]
        public string SuggestionDescription { get; set; }
    }
}
