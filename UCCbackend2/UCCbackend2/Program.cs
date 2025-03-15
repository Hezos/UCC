using UCCbackend2.Services;
using System.Security.Claims;

namespace UCCbackend2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            //Possible solution https://dotnetfullstackdev.medium.com/jwt-token-authentication-in-c-a-beginners-guide-with-code-snippets-7545f4c7c597
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication("Bearer").AddJwtBearer();


            builder.Services.AddCors(options =>
            {

                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200", "https://localhost:7274").AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IEventService, EventService>();

            builder.Services.AddCors();

            var app = builder.Build();


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

            app.UseAuthorization();


            //The longer one is the rigth token User secrets are wrong according to curl
            app.MapGet("/", () => "Hello, World!");
            app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
                .RequireAuthorization();

            app.UseHttpsRedirection();

            app.MapControllers();


            app.Run();

        }
    }
}
