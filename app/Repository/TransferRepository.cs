using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos.Transfer;
using app.helpers;
using app.Interfaces;
using app.Mappers;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class TransferRepository(ApplicationDBContext context)
        : ITransferRepository
    {
        private readonly ApplicationDBContext _context = context;
        async public Task<List<TransferDto>> GetTransfersAsync(AppUser user, QueryObject queryObject)
        {
            var transfers = await _context.Transfers.Where(
                t => t.AppUserId == user.Id
                     && t.Date >= queryObject.FrDate
                      && t.Date <= queryObject.ToDate).ToListAsync();

            return [.. transfers.Select(t => t.ToTransferDto())];
        }
        async public Task<TransferDto> CreateTransferAsync(CreateTransferDto transferDto)
        {
            var transfer = transferDto.ToTransferFromCreateDto();
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return transfer.ToTransferDto();
        }
    }
}