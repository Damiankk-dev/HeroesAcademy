using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using HeroesAcademy.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using HeroesAcademy.Application.Repository.Heroes;
using HeroesAcademy.Application.Repository.Reservations;

namespace HeroesAcademy.Application
{
    public static class ApplicationRegistry
    {
        public static void AddApplication(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IHeroRepository, HeroEFRepository>();
            services.AddScoped<IReservationRepository, ReservationEFRepository>();
            services.AddDbContext<HeroesAcademyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddDefaultIdentity<ApplicationUser>(options=>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<HeroesAcademyDbContext>();
            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, HeroesAcademyDbContext>();
            services.AddAuthentication().AddIdentityServerJwt();
        }
    }
}
