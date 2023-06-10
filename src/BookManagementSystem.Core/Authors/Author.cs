using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors
{
    public class Author : FullAuditedEntity<int>
    {
        [StringLength(50)]
        public string AuthorName { get; set; }
    }
}
