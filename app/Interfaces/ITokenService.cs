using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;

namespace app.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}