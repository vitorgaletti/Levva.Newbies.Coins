using Levva.Newbies.Coins.Business.Interfaces;
using Levva.Newbies.Coins.Business.MapperProfiles;
using Levva.Newbies.Coins.Business.Services;
using Levva.Newbies.Coins.Data;
using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Data.Repositories;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Levva.Newbies.Coins.Infra.IoC {
    public static class DependencyInjector {

        public static void AddNewbiesService(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<IContext, Context>(options => options.UseSqlite(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Levva.Newbies.Coins")));
            services.AddAutoMapper(typeof(DefaultMapper));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<IRepository<Categoria>, Repository<Categoria>>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITransacaoService, TransacaoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
        }
    }
}
