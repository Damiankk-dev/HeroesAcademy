using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace IdentityServerApplication
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "heroesAcademy",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },
                AllowedScopes = {"reservationsAPI"}
            },
            new Client
            {
                ClientId = "heroesAcademyClient",
                ClientName = "Heroes Academy Client",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    "https://localhost:7009/login"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    "https://localhost:7009/signout-callback-oidc"
                },
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "reservationsAPI"
                }
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
             new IdentityResources.OpenId(),
             new IdentityResources.Profile()
         };
        public static List<TestUser> TestUsers =>
         new List<TestUser>
         {
             new TestUser
             {
                 SubjectId = "5BE86359–073C-434B-AD2D-A3932222DABE",
                 Username = "Q@g.com",
                 Password = "D@miano0",
                 Claims = new List<Claim>
                 {
                     new Claim(JwtClaimTypes.Email, "Q@g.com")
                 }
             }
         };
    }

}
