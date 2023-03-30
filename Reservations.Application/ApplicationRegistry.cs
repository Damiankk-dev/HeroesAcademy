using HeroesAcademy.Application.Repository.Reservations;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Reservations.Application
{
    public static class ApplicationRegistry
    {
        public static void AddApplication(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IReservationRepository, ReservationEFRepository>();
            services.AddDbContext<ReservationsDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}
