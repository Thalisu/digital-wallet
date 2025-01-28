using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Transfer
{
    public class CreateTransferDto
    {
        public string ToUserId { get; set; } = null!;
        public decimal? BRL { get; set; }
        public decimal? USD { get; set; }
        public DateTime Date { get; set; }
        public string AppUserId { get; set; } = null!;
    }
}