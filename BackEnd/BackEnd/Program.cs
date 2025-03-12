using Microsoft.AspNetCore.Cors;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 //   app.UseSwagger();
  //  app.UseSwaggerUI();
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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
