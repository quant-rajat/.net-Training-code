﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class PagedResults<T>
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalRecordCount { get; set; }

        public List<T> Results { get; set; }

    }
}
