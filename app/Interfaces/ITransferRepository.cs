using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Transfer;

namespace app.Interfaces
{
    public interface ITransferRepository
    {
        Task<TransferDto> CreateTransferAsync(CreateTransferDto transferDto);
    }
}