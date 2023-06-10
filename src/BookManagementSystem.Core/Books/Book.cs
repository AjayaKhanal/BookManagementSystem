using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Books
{
    public class Book : FullAuditedEntity<int>
    {
        public string BookName { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}
