using HeroesAcademy.Application;
using HeroesAcademy.Configuration;
using HeroesAcademy.Swagger;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var MyAllowPolicy = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowPolicy, configurePolicy: policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SwaggerFileOperationFilter>();
});
builder.Services.Configure<FileServerConfiguration>(builder.Configuration.GetSection(FileServerConfiguration.SectionName));

var connectionString = builder.Configuration.GetConnectionString("HeroesAcademy");
builder.Services.AddApplication(connectionString);
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseFileServer(true);
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint(url:"v1/swagger.json", "HeroesAcademy"));
//app.UseStaticFiles(
//        new StaticFileExtensions
//    );
app.UseRouting();
app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();
app.UseCors(MyAllowPolicy);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.Run();
