using BookManagementSystem.Authors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.Authors
{
    public class AuthorListViewModel
    {
        public IReadOnlyList<AuthorDto> Author { get; set; }
    }
}
