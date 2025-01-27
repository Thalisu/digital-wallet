using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Wallet
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal BRL { get; set; }
        public decimal USD { get; set; }
    }
}