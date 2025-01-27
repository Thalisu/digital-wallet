using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public int BRL { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public int USD { get; set; }
        public string UserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
}