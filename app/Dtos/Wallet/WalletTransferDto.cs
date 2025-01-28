using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Wallet
{
    public class WalletTransferDto
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        [Range(0, 1000000000000)]
        public decimal BRL { get; set; }
        [Required]
        [Range(0, 1000000000000)]
        public decimal USD { get; set; }
    }
}