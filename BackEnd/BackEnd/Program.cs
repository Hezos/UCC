using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();


builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "http://localhost:7159").AllowAnyHeader().AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
});

//UseCors must be placed after "UseRouting", but before "UseAuthorization"

app.UseCors(
    options =>
    {
        // options.WithOrigins(https://localhost:7159);
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
);


app.UseCors(MyAllowSpecificOrigins);



app.MapGet("/", () => "Hello, World!");
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
    .RequireAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
