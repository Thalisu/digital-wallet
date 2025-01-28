using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using app.Dtos.User;
using app.Models;
using Microsoft.AspNetCore.Identity;

namespace app.Data
{
    public static class Users
    {
        public static List<RegisterDto> UsersFakeList(this UserManager<AppUser> _)
        {
            var users = new List<RegisterDto>{
                new () {
                    Email = "alice@example.com",
                    Username =  "alice123",
                    Password =  "P@ssw0rd!1"
                },
                new () {
                    Email = "bob@example.com",
                    Username =  "bob_the_builder",
                    Password =  "B0bP@ss!23"
                },
                new () {
                    Email = "charlie@example.com",
                    Username =  "charlie_the_champ",
                    Password =  "C#harl1e!@23"
                },
                new () {
                    Email = "diana@example.com",
                    Username =  "diana_queen",
                    Password =  "D!@naQn#321"
                },
                new () {
                    Email = "eve@example.com",
                    Username =  "eve_the_educator",
                    Password =  "Eve@123Pass"
                },
                new () {
                    Email = "frank@example.com",
                    Username =  "frank_the_fantastic",
                    Password =  "Fr@nkP@ss44"
                },
                new () {
                    Email = "grace@example.com",
                    Username =  "grace_smith",
                    Password =  "Gr@c3S!m!th"
                },
                new () {
                    Email = "hannah@example.com",
                    Username =  "hannah_dev",
                    Password =  "H@nn@hDev99"
                },
                new () {
                    Email = "ian@example.com",
                    Username =  "ian_techie",
                    Password =  "I@nt3ch!e!"
                },
                new () {
                    Email = "jack@example.com",
                    Username =  "jack_the_jackal",
                    Password =  "J@ck!J@ck12"
                }
            };
            return users;
        }
    }
}