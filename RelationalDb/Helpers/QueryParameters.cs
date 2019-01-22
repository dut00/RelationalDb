using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Helpers
{
    public class QueryParameters
    {
        public string SortBy { get; set; }
        public string OrderBy { get; set; } = "asc";

        public bool Details { get; set; } = false;

    }
}
