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
        Task<WalletDto> GetWalletAsync(AppUser user);
        Task<WalletDto> AddWalletAsync(AppUser user);
        Task<Wallet> UpdateWalletAsync(UpdateWalletDto walletDto);
        Task<bool> TransferAsync(AppUser sender, TransferDto receiver);
        Task<Wallet> DeleteWalletAsync(AppUser user);
    }
}