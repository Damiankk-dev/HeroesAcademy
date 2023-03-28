using Duende.IdentityServer.EntityFramework.Options;
using HeroesAcademy.Domain.Models.Reservations;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HeroesAcademy.Application.Repository.Reservations
{
    internal class ReservationsDbContext: ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Reservation> Reservations { get; set; }
        public ReservationsDbContext(DbContextOptions<ReservationsDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Reservation>().HasData(new Reservation()
            {
                Id = 2,
                RoomId = 1,
                TenantId = 1,
                ReservationEnd = DateTime.UtcNow,
                ReservationStart = DateTime.UtcNow
            });
            builder.Entity<Reservation>().HasData(new Reservation()
            {
                Id = 3,
                RoomId = 1,
                TenantId = 2,
                ReservationEnd = DateTime.UtcNow,
                ReservationStart = DateTime.UtcNow
            });
        }
    }
}
