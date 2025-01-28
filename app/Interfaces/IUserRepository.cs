using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.User;
using app.Models;
using Microsoft.AspNetCore.Identity;

namespace app.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        Task<AppUser?> GetUserAsync(LoginDto loginDto);
        Task<List<UserConsultDto>> GetUsersAsync();
        Task<SignInResult> CheckPasswordAsync(AppUser user, string password);
        Task<IdentityResult> AddRoleAsync(AppUser user, string role);
        Task<List<UserDto>> Populate();
    }
}