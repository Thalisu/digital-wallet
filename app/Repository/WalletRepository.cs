using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos.Transfer;
using app.Dtos.Wallet;
using app.Interfaces;
using app.Mappers;
using app.Models;
using Microsoft.EntityFrameworkCore;

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
        async public Task<WalletDto?> GetWalletAsync(AppUser user)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(
                w => w.UserId == user.Id);
            return wallet?.ToWalletDto();
        }
        async public Task<WalletDto?> UpdateWalletAsync(
            AppUser user, UpdateWalletDto walletDto)
        {
            var wallet = await _context.Wallets.FirstOrDefaultAsync(
                w => w.UserId == user.Id);
            if (wallet == null)
            {
                return null;
            }

            wallet.BRL = walletDto.BRL;
            wallet.USD = walletDto.USD;

            await _context.SaveChangesAsync();
            return wallet.ToWalletDto();
        }
        async public Task<TransferResultDto> TransferAsync(AppUser sender, WalletTransferDto receiver)
        {
            var senderWallet = await _context.Wallets.FirstOrDefaultAsync(
                w => w.UserId == sender.Id);
            var receiverWallet = await _context.Wallets.FirstOrDefaultAsync(
                w => w.UserId == receiver.UserId);

            var TransferResultDto = new TransferResultDto();

            if (receiverWallet == null || senderWallet == null)
            {
                TransferResultDto.Error = "Sender user or receiver not found";
                return TransferResultDto;
            }
            if (senderWallet.UserId == receiver.UserId)
            {
                TransferResultDto.Error = "Sender and receiver cannot be the same user";
                return TransferResultDto;
            }
            if (senderWallet.BRL < receiver.BRL || senderWallet.USD < receiver.USD)
            {
                TransferResultDto.Error = "Insufficient funds";
                return TransferResultDto;
            }
            if (receiver.BRL == 0 && receiver.USD == 0)
            {
                TransferResultDto.Error = "Amount cannot be zero";
                return TransferResultDto;
            }

            var transfer = new Transfer
            {
                AppUserId = sender.Id,
                ToUserId = receiver.UserId,
                BRL = receiver.BRL == 0 ? null : receiver.BRL,
                USD = receiver.USD == 0 ? null : receiver.USD,
                Date = DateTime.UtcNow,
            };

            await _context.Transfers.AddAsync(transfer);

            senderWallet.BRL -= receiver.BRL;
            receiverWallet.BRL += receiver.BRL;
            senderWallet.USD -= receiver.USD;
            receiverWallet.USD += receiver.USD;

            await _context.SaveChangesAsync();

            TransferResultDto.Transfer = transfer.ToTransferDto();
            return TransferResultDto;
        }
    }
}