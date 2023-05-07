using Duende.IdentityServer.EntityFramework.Options;
using HeroesAcademyClient.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HeroesAcademyClient
{
    public class UserDbContext:ApiAuthorizationDbContext<User>
    {
        public UserDbContext(
            DbContextOptions<UserDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
                : base(options, operationalStoreOptions)
        {
        }
    }
}
