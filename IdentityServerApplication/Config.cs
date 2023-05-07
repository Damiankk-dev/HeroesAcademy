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
                ClientId = "heroesAcademyClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },
                AllowedScopes = {"reservationsAPI"}
            },
            new Client
            {
                ClientId = "reservations_app",
                ClientName = "Reservations Application",
                AllowedGrantTypes = GrantTypes.Code,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    "https://localhost:7241/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    "https://localhost:7241/signout-callback-oidc"
                },
                ClientSecrets =
                {
                    new IdentityServer4.Models.Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
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
                 Username = "admin",
                 Password = "admin",
                 Claims = new List<Claim>
                 {
                     new Claim(JwtClaimTypes.GivenName, "admin"),
                     new Claim(JwtClaimTypes.FamilyName,"admin")
                 }
             }
         };
    }

}
