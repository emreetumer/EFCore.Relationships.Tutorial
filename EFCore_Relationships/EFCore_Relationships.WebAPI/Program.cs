using EFCore_Relationships.WebAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Service Registration

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
    options.UseSqlServer(connectionString);
});


var app = builder.Build();
//Middleware





app.Run();