using Reservations.Application;
using JwtAuthenticationManager;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ReservationsAPI;

var builder = WebApplication.CreateBuilder(args);
var myAllowPolicy = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowPolicy, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var securityDefinition = new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    };
    opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityDefinition);
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityDefinition, Array.Empty<string>()}
    });

    opt.OperationFilter<AuthResponsesOperationFilter>();
});
builder.Services.AddCustomJwtAuthentication();


var connectionString = builder.Configuration.GetConnectionString("Reservations");
builder.Services.AddApplication(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(myAllowPolicy);

app.MapControllers();

app.Run();
