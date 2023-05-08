using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotBasic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var authenticationProviderKey = "IdentityApiKey";

            // Add services to the container.

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("configuration.json")
                .AddJsonFile("appsettings.json");

            builder.Services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
                {
                    x.Authority = "https://localhost:7058";
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();
            builder.Services.AddOcelot();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);

            var app = builder.Build();

            //app.UseOcelot().Wait();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerForOcelotUI(opt => {
                    opt.PathToSwaggerGenerator = "/swagger/docs";
                })
                    .UseOcelot()
                    .Wait();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            //builder
            //builder.UseContentRoot(Directory.GetCurrentDirectory())
            //.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config
            //        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            //        .AddJsonFile("appsettings.json", true, true)
            //        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            //        .AddJsonFile("configuration.json")
            //        .AddEnvironmentVariables();
            //})
            //.ConfigureServices(s => {
            //    s.AddOcelot();
            //    s.AddSwaggerGen();
            //    s.AddSwaggerForOcelot();
            //})
            //.ConfigureLogging((hostingContext, logging) =>
            //{
            //    logging.AddConsole();
            //})
            //.UseIISIntegration()
            //.Configure(app =>
            //{
            //    app.UseOcelot().Wait();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Heroes Academy API"));
            //})
            //.Build()

            //.Run();
        }
    }
}