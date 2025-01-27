using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Wallet
{
    public class UpdateWalletDto
    {
        [Required]
        [Range(0, 1000000000000)]
        public int BRL { get; set; }
        [Required]
        [Range(0, 1000000000000)]
        public int USD { get; set; }
    }
}