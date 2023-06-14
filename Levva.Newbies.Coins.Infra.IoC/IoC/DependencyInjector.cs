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
            services.AddDbContext<IContext, Context>(options => options.UseSqlite(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)));
            services.AddAutoMapper(typeof(DefaultMapper));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
