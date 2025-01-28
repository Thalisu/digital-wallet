using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Transfer;
using app.helpers;
using app.Models;

namespace app.Interfaces
{
    public interface ITransferRepository
    {
        Task<List<TransferDto>> GetTransfersAsync(AppUser user, QueryObject queryObject);
        Task<TransferDto> CreateTransferAsync(CreateTransferDto transferDto);
    }
}