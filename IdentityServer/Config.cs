using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
               new Client
                {
                    ClientName = "Angular-Client",
                    ClientId = "angular-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "http://localhost:4200/signin-callback", "http://localhost:4200/assets/silent-callback.html" },
                    RequirePkce = false,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "reservationsApi",
                        "heroesApi"
                    },
                AllowedCorsOrigins = { "http://localhost:4200" },
                RequireClientSecret = false,
                PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
                RequireConsent = false,
                AccessTokenLifetime = 600
                }
        };
        public static IEnumerable<ApiScope> ApiScopes =>
         new ApiScope[]
         {
             new ApiScope("reservationsApi", "Reservations API"),
             new ApiScope("heroesApi", "Heroes API")
         };
        public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("reservationsApi", "Reservations API")
             {
                 Scopes = {"reservationsApi"}
             },
            new ApiResource("heroesApi", "Heroes API")
            {
                Scopes = { "heroesApi" }
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
         new IdentityResource[]
         {
             new IdentityResources.OpenId(),
             new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResource("roles", "User role(s)", new List<string> { "role" })
         };
        public static List<TestUser> GetUsers() =>
          new List<TestUser>
          {
              new TestUser
              {
                  SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                  Username = "admin",
                  Password = "AdminPassword",
                  Claims = new List<Claim>
                  {
                      new Claim("role", "Admin")
                  }
              },
              new TestUser
              {
                  SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                  Username = "visit",
                  Password = "VisitPassword",
                  Claims = new List<Claim>
                  {
                      new Claim("role", "Visitor")
                  }
              }
          };
    }

}
