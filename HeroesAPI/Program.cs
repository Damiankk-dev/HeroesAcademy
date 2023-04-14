using HeroesAcademy.Application;
using HeroesAcademy.Configuration;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var myAllowPolicy = "_myAllowSpecificOrigins";

//Add services to the container.
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
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("HeroesAcademy");
builder.Services.AddApplication(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var options = app.Services.GetRequiredService<IOptions<FileServerConfiguration>>();
//app.UseStaticFiles(
//    new StaticFileOptions
//    {
//        FileProvider = new PhysicalFileProvider($"{Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures)}"),
//        RequestPath = options.Value.RequestPath,
//        ContentTypeProvider = new FileExtensionContentTypeProvider()
//    });

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();

app.UseCors(myAllowPolicy);

app.MapControllers();

app.Run();
