using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace app.Models
{
    public class AppUser : IdentityUser
    {
        public Wallet Wallet { get; set; } = null!;
        public ICollection<Transfer> Transfers { get; set; } = [];
    }
}