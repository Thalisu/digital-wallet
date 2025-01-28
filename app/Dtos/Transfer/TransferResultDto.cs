using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.Transfer
{
    public class TransferResultDto
    {
        public string? Error { get; set; }
        public TransferDto? Transfer { get; set; }
    }
}