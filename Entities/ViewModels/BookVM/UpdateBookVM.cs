﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Book
{
    public class UpdateBookVM
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookISBN { get; set; }
    }
}
