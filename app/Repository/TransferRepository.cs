using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos.Transfer;
using app.Interfaces;
using app.Mappers;

namespace app.Repository
{
    public class TransferRepository(ApplicationDBContext context)
        : ITransferRepository
    {
        private readonly ApplicationDBContext _context = context;
        async public Task<TransferDto> CreateTransferAsync(CreateTransferDto transferDto)
        {
            var transfer = transferDto.ToTransferFromCreateDto();
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return transfer.ToTransferDto();
        }
    }
}