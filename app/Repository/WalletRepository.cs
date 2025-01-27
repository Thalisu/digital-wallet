using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos.Wallet;
using app.Interfaces;
using app.Mappers;
using app.Models;

namespace app.Repository
{
    public class WalletRepository(ApplicationDBContext context) : IWalletRepository
    {
        private readonly ApplicationDBContext _context = context;

        async public Task<WalletDto> AddWalletAsync(AppUser user)
        {
            var wallet = new Wallet
            {
                UserId = user.Id,
                BRL = 0,
                USD = 0
            };
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet.ToWalletDto();
        }
        async public Task<Wallet> DeleteWalletAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
        async public Task<WalletDto> GetWalletAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
        async public Task<Wallet> UpdateWalletAsync(UpdateWalletDto walletDto)
        {
            throw new NotImplementedException();
        }
        async public Task<bool> TransferAsync(AppUser sender, TransferDto receiver)
        {
            throw new NotImplementedException();
        }
    }
}