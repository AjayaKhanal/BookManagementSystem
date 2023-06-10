using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks
{
    public class EBook : FullAuditedEntity<int>
    {
        public string EBookName { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        
    }
}
