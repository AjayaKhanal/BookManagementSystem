using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks.Dto
{
    public class CreateEBookDto
    {
        [Required]
        public string EBookName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FilePath { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
