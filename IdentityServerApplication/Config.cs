using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace IdentityServerApplication
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "heroesAcademyClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },
                AllowedScopes = {"reservationsAPI"}
            }
        };
        public static IEnumerable<ApiScope> ApiScopes =>
         new ApiScope[]
         {
             new ApiScope("reservationsAPI", "Reservations API")
         };
        public static IEnumerable<ApiResource> ApiResources =>
         new ApiResource[]
         {
         };
        public static IEnumerable<IdentityResource> IdentityResources =>
         new IdentityResource[]
         {
         };
        public static List<TestUser> TestUsers =>
         new List<TestUser>
         {
         };
    }

}
