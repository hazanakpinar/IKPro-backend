using IKPro.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace IKPro.Infrastructure.Data
{
    public class IKProDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _iconfig;
        public IKProDbContext()
        {
        }

        public IKProDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Paket> Paketler { get; set; }
        public DbSet<Sirket> Sirketler { get; set; }
        public DbSet<AvansTalep> AvansTalepleri { get; set; }
        public DbSet<HarcamaTalep> HarcamaTalepleri { get; set; }
        public DbSet<IzinTalep> IzinTalepleri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStrings",
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,     // Maksimum yeniden deneme sayısı
                maxRetryDelay: TimeSpan.FromSeconds(10), // Yeniden denemeler arası maksimum bekleme süresi
                errorNumbersToAdd: null));// Özel hata numaraları eklemek isterseniz);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 3 }
                );

        }
    }
}
