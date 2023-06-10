using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBooks.Dto
{
    public class EBookListDto
    {
        public string EBookName { get; set; }
        public string Description { get; set; }
        public SecureString FilePath { get; set; }
    }
}
