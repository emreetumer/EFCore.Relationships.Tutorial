using EFCore_Relationships.WebAPI.Context;
using EFCore_Relationships.WebAPI.Dtos;
using EFCore_Relationships.WebAPI.Models;
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

app.MapPost("user-create", (ApplicationDbContext context, UserCreateDto request) =>
{
    User user = new()
    {
        FirstName = request.FirstName,
        LastName = request.LastName,
        UserInformation = new()
        {
            IdentityNumber = request.IdentityNumber,
            FullAddress = request.FullAddress,
        }
    };

    context.Add(user);
    context.SaveChanges();

    return Results.Ok(user);
});

app.MapGet("user-getall", (ApplicationDbContext context) =>
{
    var users = context.Users.Include(p => p.UserInformation).ToList();

    return users;
});


app.Run();