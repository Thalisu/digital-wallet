using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Wallet;
using app.Models;

namespace app.Mappers
{
    public static class WalletMapper
    {
        public static WalletDto ToWalletDto(this Wallet wallet)
        {
            return new WalletDto
            {
                Id = wallet.Id,
                BRL = wallet.BRL,
                USD = wallet.USD
            };
        }
    }
}