using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Class.Article_Grid.grid_search_remote_csharp_backend
{
    public class Filter
    {
        public string Property { get; set; }
        public string Value { get; set; }
        public bool AnyMatch { get; set; }
        public bool CaseSensitive { get; set; }
    }
}