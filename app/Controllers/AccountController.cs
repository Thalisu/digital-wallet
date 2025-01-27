using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.User;
using app.Interfaces;
using app.Mappers;
using app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController(
        IUserRepository userRepository,
        ITokenService tokenService) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenService _tokenService = tokenService;
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var result = await _userRepository.CreateAsync(
                user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roleResult = await _userRepository.AddRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                return StatusCode(500, roleResult.Errors);
            }

            return Ok(user.ToUserDto(_tokenService.CreateToken(user)));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserAsync(loginDto);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }

            var result = await _userRepository.CheckPasswordAsync(
                user, loginDto.Password);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Ok(user.ToUserDto(_tokenService.CreateToken(user)));
        }
    }
}