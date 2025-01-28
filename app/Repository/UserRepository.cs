using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.Dtos.User;
using app.Interfaces;
using app.Mappers;
using app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class UserRepository(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IWalletRepository walletRepository,
        ITokenService tokenService
        ) : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly IWalletRepository _walletRepository = walletRepository;
        private readonly ITokenService _tokenService = tokenService;

        async public Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        async public Task<AppUser?> GetUserAsync(LoginDto loginDto)
        {
            var hasEmail = !string.IsNullOrEmpty(loginDto.Email);
            var hasUser = !string.IsNullOrEmpty(loginDto.Username);
            if (!hasEmail && !hasUser)
            {
                return null;
            }

            return hasEmail
                ? await _userManager.Users.FirstOrDefaultAsync(
                    u => u.Email == loginDto.Email)
                : await _userManager.Users.FirstOrDefaultAsync(
                    u => u.UserName == loginDto.Username);
        }
        async public Task<IdentityResult> AddRoleAsync(AppUser user, string role = "User")
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
        async public Task<SignInResult> CheckPasswordAsync(AppUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

        async public Task<List<UserDto>> Populate()
        {
            List<UserDto> users = [];
            var dtos = _userManager.UsersFakeList();
            foreach (var dto in dtos)
            {
                var user = new AppUser
                {
                    UserName = dto.Username,
                    Email = dto.Email
                };
                var result = await CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    continue;
                }
                result = await AddRoleAsync(user, "User");
                if (!result.Succeeded)
                {
                    continue;
                }
                await _walletRepository.AddWalletAsync(user);

                users.Add(user.ToUserDto(_tokenService.CreateToken(user)));
            }
            return users;
        }

        async public Task<List<UserConsultDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return [.. users.Select(u => u.ToUserConsultDto())];
        }
    }
}