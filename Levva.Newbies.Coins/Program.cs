using Levva.Newbies.Coins.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Levva.Newbies.Coins;

public class Program {

    public static void Main(string[] args) {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<Context>(
            options => options.UseSqlite(builder.Configuration
            .GetConnectionString("Default"), 
            b => b.MigrationsAssembly("Levva.Newbies.Coins")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        var cultureInfo = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        app.Run();
    }
}



