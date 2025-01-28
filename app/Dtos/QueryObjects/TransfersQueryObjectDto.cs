using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.QueryObjects
{
    public class TransfersQueryObjectDto
    {
        public DateTime FrDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}