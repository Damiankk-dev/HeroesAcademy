using HeroesAcademyClient;
using HeroesAcademyClient.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myAllowPolicy = "_myAllowSpecificOrigins";
var connectionString = builder.Configuration.GetConnectionString("Authentication");

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowPolicy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequiredLength = 6;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
 .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
 .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
 {
     options.Authority = "https://localhost:7058";

     options.ClientId = "shopping_web";
     options.ClientSecret = "secret";
     options.ResponseType = "code";

     options.Scope.Add("openid");
     options.Scope.Add("profile");
     options.SaveTokens = true;
     options.GetClaimsFromUserInfoEndpoint = true;
 });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseCors(myAllowPolicy);

app.MapControllers();
app.MapRazorPages(); 

app.Run();
