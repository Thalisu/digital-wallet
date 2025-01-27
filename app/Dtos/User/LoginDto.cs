using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app.Dtos.User
{
    public class LoginDto
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }
}