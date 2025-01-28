using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Transfer;
using app.Models;

namespace app.Interfaces
{
    public interface ITransferRepository
    {
        Task<List<TransferDto>> GetTransfersAsync(AppUser user);
        Task<TransferDto> CreateTransferAsync(CreateTransferDto transferDto);
    }
}