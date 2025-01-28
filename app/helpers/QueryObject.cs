using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.helpers
{
    public class QueryObject
    {
        public DateTime? FrDate { get; set; } = DateTime.MinValue;
        public DateTime? ToDate { get; set; } = DateTime.MaxValue;
    }
}