using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_new.helpers
{
    public class QueryObject
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
    }
}