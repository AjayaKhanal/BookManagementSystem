using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Books.Dto
{
    public class BookListDto
    {
        public string BookName { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
