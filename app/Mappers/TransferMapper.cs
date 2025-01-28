using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Transfer;
using app.Models;

namespace app.Mappers
{
    public static class TransferMapper
    {
        public static Transfer ToTransferFromCreateDto(
            this CreateTransferDto transferDto)
        {
            return new Transfer
            {
                AppUserId = transferDto.AppUserId,
                ToUserId = transferDto.ToUserId,
                BRL = transferDto.BRL,
                USD = transferDto.USD,
                Date = DateTime.UtcNow,
            };
        }
        public static TransferDto ToTransferDto(
            this Transfer transfer)
        {
            return new TransferDto
            {
                Id = transfer.Id,
                AppUserId = transfer.AppUserId,
                ToUserId = transfer.ToUserId,
                BRL = transfer.BRL,
                USD = transfer.USD,
                Date = DateTime.UtcNow,
            };
        }
    }
}