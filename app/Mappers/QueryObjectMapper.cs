using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.QueryObjects;
using app.helpers;

namespace app.Mappers
{
    public static class QueryObjectMapper
    {
        public static TransfersQueryObjectDto ToTransfersQueryObjectDto(
            this QueryObject queryObject)
        {
            DateTime FrDate = queryObject.FrDate == null
                ? DateTime.MinValue
                : DateTime.ParseExact(queryObject.FrDate, "dd-MM-yyyy", null)
                  .ToUniversalTime();
            DateTime ToDate = queryObject.ToDate == null
                ? DateTime.MaxValue
                : DateTime.ParseExact(queryObject.ToDate, "dd-MM-yyyy", null)
                  .AddHours(23).AddMinutes(59).AddSeconds(59).ToUniversalTime();

            return new TransfersQueryObjectDto
            {
                FrDate = FrDate,
                ToDate = ToDate
            };
        }

    }
}