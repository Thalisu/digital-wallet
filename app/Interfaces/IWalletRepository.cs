using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Wallet;
using app.Models;

namespace app.Interfaces
{
    public interface IWalletRepository
    {
        Task<WalletDto?> GetWalletAsync(AppUser user);
        Task<WalletDto> AddWalletAsync(AppUser user);
        Task<WalletDto?> UpdateWalletAsync(AppUser user, UpdateWalletDto walletDto);
        Task<bool> TransferAsync(AppUser sender, TransferDto receiver);
    }
}