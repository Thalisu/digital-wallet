using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.User;
using app.Interfaces;
using app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class UserRepository(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager) : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;

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
        async public Task<IdentityResult> AddRoleAsync(AppUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, "User");
        }
        async public Task<SignInResult> CheckPasswordAsync(AppUser user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

    }
}