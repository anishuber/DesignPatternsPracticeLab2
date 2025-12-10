using Task2.Clients;
using Task2.Controllers;
using Task2.Data;
using Task2.Interfaces;

namespace Task2
{
    public static class BuildApp
    {
        public static WebApplication BuildWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddApplicationPart(typeof(SomeEntityController).Assembly).AddApplicationPart(typeof(SomeImageEntityController).Assembly);
            builder.Services.AddSingleton<ISomeEntityRepository, SomeEntityRepository>();
            builder.Services.AddSingleton<ISomeImageEntityRepository, SomeImageEntityRepository>();
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

            return app;
        }
    }
}
