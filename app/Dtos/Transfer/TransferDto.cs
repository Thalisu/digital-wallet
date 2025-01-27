using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Transfer
{
    public class TransferDto
    {
        public int Id { get; set; }
        public string ToUsername { get; set; } = "";
        public int ToWalletId { get; set; }
        public decimal? BRL { get; set; }
        public decimal? USD { get; set; }
        public DateTime Date { get; set; }
        public string AppUserId { get; set; } = null!;
    }
}