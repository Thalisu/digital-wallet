using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Dtos.User;
using app.Models;

namespace app.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this AppUser user, string token)
        {

            if (user.Email == null || user.UserName == null)
            {
                throw new ArgumentNullException(user.Email, user.UserName);
            }
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Token = token
            };
        }
        public static UserConsultDto ToUserConsultDto(this AppUser user)
        {
            if (user.Email == null || user.UserName == null)
            {
                throw new ArgumentNullException(user.Email, user.UserName);
            }
            return new UserConsultDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName
            };
        }
    }
}