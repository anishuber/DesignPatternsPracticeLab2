
using Server.Data;
using Server.Interfaces;
using Server.Services;

namespace Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddSingleton<ISomeEntityRepository, SomeEntityRepository>();
            builder.Services.AddSingleton<ISomeImageEntityRepository, SomeImageEntityRepository>();
            builder.Services.AddSingleton<SomeImageEntityService>();
            builder.Services.AddSingleton<ISomeImageEntityService>(sp => new SomeImageEntityServiceProxy(sp.GetRequiredService<SomeImageEntityService>()));

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
