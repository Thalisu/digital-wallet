using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class ApplicationDBContext(
        DbContextOptions<ApplicationDBContext> dbContextOptions)
        : IdentityDbContext<AppUser>(dbContextOptions)
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Wallet)
                    .WithOne(w => w.AppUser)
                .HasForeignKey<Wallet>(w => w.UserId)
                .IsRequired();

            List<IdentityRole> roles = [
                new(){
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new(){
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}