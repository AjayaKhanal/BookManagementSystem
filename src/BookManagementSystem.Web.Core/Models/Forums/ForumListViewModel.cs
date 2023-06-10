using BookManagementSystem.Forums.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.Forums
{
    public class ForumListViewModel
    {
        public IReadOnlyList<ForumDto> Forum { get; set; }
    }
}
