using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Todo.Application.Repositories;
using Todo.Persistence.Contexts;
using Todo.Persistence.Repositories;

namespace Blog.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfDbContext>(conf =>
            {
                var connStr = configuration["EfDbContext"].ToString();
                conf.UseNpgsql(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

         //var seedData = new SeedData();
         //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            services.AddScoped<DbContext, EfDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }

}
