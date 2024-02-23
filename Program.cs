
using Microsoft.EntityFrameworkCore;

namespace LoginApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Context")
            ?? throw new InvalidOperationException("Connection string 'Context' not found.")));

            builder.Services.AddControllers();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<Context>();
       
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
     
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
