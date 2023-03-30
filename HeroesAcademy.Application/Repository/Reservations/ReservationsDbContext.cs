using Duende.IdentityServer.EntityFramework.Options;
using HeroesAcademy.Domain.Models.Reservations;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HeroesAcademy.Application.Repository.Reservations
{
    internal class ReservationsDbContext: DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Reservation>().HasData(new Reservation()
            {
                Id = 2,
                ReservationEnd = DateTime.UtcNow,
                ReservationStart = DateTime.UtcNow,
                RoomId = 1,
                TenantId = 1
            });
            builder.Entity<Reservation>().HasData(new Reservation()
            {
                Id = 3,
                ReservationEnd = DateTime.UtcNow,
                ReservationStart = DateTime.UtcNow,
                RoomId = 1,
                TenantId = 1
            });
            builder.Entity<Room>().HasData(new Room()
            {
                Id = 1,
                Name = "WestRoom",
                Volume = 10
            });
            builder.Entity<Tenant>().HasData(new Tenant()
            {
                Id = 1,
            });
        }
    }
}
