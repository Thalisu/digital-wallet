using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Transfer;
using app.Extensions;
using app.Interfaces;
using app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("/transfer")]
    public class TransferController(
        ITransferRepository transferRepository,
        UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly ITransferRepository _transferRepository = transferRepository;
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> GetTransfers()
        {
            var username = User.GetUsername();
            if (username == null)
            {
                return Unauthorized();
            }
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
            {
                return Unauthorized();
            }

            var transfers = await _transferRepository.GetTransfersAsync(appUser);

            return Ok(transfers);
        }
    }
}