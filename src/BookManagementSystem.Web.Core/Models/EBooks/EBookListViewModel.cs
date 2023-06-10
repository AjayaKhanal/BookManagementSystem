﻿using BookManagementSystem.EBooks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Models.EBooks
{
    public class EBookListViewModel
    {
        public IReadOnlyList<EBookDto> EBook { get; set; }
    }
}
