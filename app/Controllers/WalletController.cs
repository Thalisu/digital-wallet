using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.Wallet;
using app.Extensions;
using app.Interfaces;
using app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [ApiController]
    [Route("/wallet")]
    public class WalletController(IWalletRepository walletRepository, UserManager<AppUser> userManager)
        : ControllerBase
    {
        private readonly IWalletRepository _walletRepository = walletRepository;
        private readonly UserManager<AppUser> _userManager = userManager;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetWalletAsync()
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
            var userWallet = await _walletRepository.GetWalletAsync(appUser);
            return Ok(userWallet);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateWalletAsync(UpdateWalletDto walletDto)
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
            var userWallet = await _walletRepository.UpdateWalletAsync(appUser, walletDto);
            return Ok(userWallet);
        }
        [HttpPut("transfer")]
        [Authorize]
        public async Task<IActionResult> TransferAsync(TransferDto transferDto)
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
            var userWallet = await _walletRepository.TransferAsync(appUser, transferDto);
            return Ok(userWallet);
        }
    }
}